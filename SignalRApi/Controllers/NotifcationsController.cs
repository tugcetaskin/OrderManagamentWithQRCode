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
    public class NotifcationsController : ControllerBase
    {
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;

        public NotifcationsController(INotificationService notificationService, IMapper mapper)
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
            _notificationService.TAdd(new Notification()
            {
                Date = DateTime.Now,
                Description = dto.Description,
                Icon = dto.Icon,
                Status = false
            });
            return Ok("Bildirim Başarı İle Eklendi");
        }

        [HttpPut]
        public IActionResult UpdateNotification(UpdateNotificationDTO dto)
        {
            _notificationService.TUpdate(new Notification()
            {
                Date = dto.Date,
                Description = dto.Description,
                Icon = dto.Icon,
                Status = dto.Status
            });
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
            var notification = _notificationService.TGetById(id);
            return Ok(notification);
        }

        [HttpGet("GetNotificationCount")]
        public IActionResult GetNotificationCount()
        {
            var count = _notificationService.TGetUnreadNotificationCount();
            return Ok(count);
        }
    }
}
