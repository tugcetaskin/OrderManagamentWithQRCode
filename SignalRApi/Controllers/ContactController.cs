using AutoMapper;
using BusinessLayer.Abstract;
using DTOLayer.ContactDTO;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public ContactController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ContactList()
        {
            var values = _mapper.Map<List<ResultContactDTO>>(_contactService.TGetListAll());
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateContact(CreateContactDTO contactDto)
        {
            var value = _mapper.Map<Contact>(contactDto);
            _contactService.TAdd(value);
            return Ok("Yeni İletişim Başarılı Bir Şekilde Eklendi.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteContact(int id)
        {
            var contact = _contactService.TGetById(id);
            _contactService.TDelete(contact);
            return Ok("İletişim Bilgisi Silindi.");
        }

        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDTO updateContactDTO)
        {
            var value = _mapper.Map<Contact>(updateContactDTO);
            _contactService.TUpdate(value);
            return Ok("İletişim Güncellendi.");
        }

        [HttpGet("{id}")]
        public IActionResult GetContact(int id)
        {
            var value = _mapper.Map<GetContactDTO>(_contactService.TGetById(id));
            return Ok(value);
        }

        [HttpGet("GetLast")]
        public IActionResult GetLast()
        {
            var value = _contactService.TGetLast();
            return Ok(value);
        }
    }
}
