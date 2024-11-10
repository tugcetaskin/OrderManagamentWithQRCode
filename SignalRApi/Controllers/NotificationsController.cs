using AutoMapper;
using BusinessLayer.Abstract;
using DTOLayer.NotificationDTO;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;

        public NotificationsController(INotificationService notificationService, IMapper mapper)
        {
            _notificationService = notificationService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var values = _mapper.Map<List<ResultNotificationDTO>>(_notificationService.TGetListAll());
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateNotification(CreateNotificationDTO dto)
        {
            dto.Date = DateTime.Now;
            dto.Status = false;
            var value = _mapper.Map<Notification>(dto);
            _notificationService.TAdd(value);
            return Ok("Bildirim Başarı İle Eklendi");
        }

        [HttpPut]
        public IActionResult UpdateNotification(UpdateNotificationDTO dto)
        {
            var value = _mapper.Map<Notification>(dto);
            _notificationService.TUpdate(value);
            return Ok("Bildirim Alanı Başarı İle Güncellendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteNotification(int id)
        {
            var notification = _notificationService.TGetById(id);
            _notificationService.TDelete(notification);
            return Ok("Bildirim Alanı Başarı İle Silindi.");
        }

        [HttpGet("{id}")]
        public IActionResult GetNotificationById(int id)
        {
            var value = _mapper.Map<GetNotificationDTO>(_notificationService.TGetById(id));
            return Ok(value);
        }

        [HttpGet("GetNotificationCount")]
        public IActionResult GetNotificationCount()
        {
            var count = _notificationService.TGetUnreadNotificationCount();
            return Ok(count);
        }

        [HttpGet("MarkAsRead/{id}")]
        public IActionResult MarkAsRead(int id)
        {
            var status = _notificationService.TGetStatus(id);
            if(status == false)
            {
                _notificationService.TMarkAsRead(id);
                return Ok("Bildirim Okundu Olarak İşaretlendi.");
            }
            return Ok("Bildirim Durumu : Okundu. İşlem Yapılmadı.");
        }

        [HttpGet("MarkAsUnread/{id}")]
        public IActionResult MarkAsUnread(int id)
        {
            var status = _notificationService.TGetStatus(id);
            if (status == true)
            {
                _notificationService.TMarkAsUnread(id);
                return Ok("Bildirim Okunmadı Olarak İşaretlendi.");
            }
            return Ok("Bildirim Durumu : Okunmadı. İşlem Yapılmadı.");
        }
    }
}
