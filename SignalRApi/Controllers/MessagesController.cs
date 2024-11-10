using AutoMapper;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using DTOLayer.MessageDTO;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageDal _messageDal;
        private readonly IMapper _mapper;

        public MessagesController(IMessageDal messageDal, IMapper mapper)
        {
            _messageDal = messageDal;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetMessageList()
        {
            var values = _mapper.Map<List<ResultMessageDTO>>(_messageDal.GetListAll());
            return Ok(values);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMessage(int id)
        {
            var mes = _messageDal.GetById(id);
            _messageDal.Delete(mes);
            return Ok("Mesaj Başarı İle Silindi.");
        }

        [HttpPut]
        public IActionResult UpdateMessage(UpdateMessageDTO message)
        {
            var value = _mapper.Map<Message>(message);
            _messageDal.Update(value);
            return Ok("Mesaj Başarı İle Güncellendi");
        }

        [HttpPost]
        public IActionResult CreateMessage(CreateMessageDTO message)
        {
            var value = _mapper.Map<Message>(message);
            _messageDal.Add(value);
            return Ok("Mesaj Başarı İle Gönderildi");
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var mes = _mapper.Map<GetMessageDTO>(_messageDal.GetById(id));
            return Ok(mes);
        }

        [HttpGet("GetUnreadMessages")]
        public IActionResult GetUnreadMessages()
        {
            var values = _mapper.Map<List<ResultMessageDTO>>(_messageDal.GetUnread());
            return Ok(values);
        }
    }
}
