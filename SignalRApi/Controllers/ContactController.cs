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
            _contactService.TAdd(new Contact()
            {
                Location = contactDto.Location,
                Phone = contactDto.Phone,
                Email = contactDto.Email,
                FooterDescription = contactDto.FooterDescription
            });
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
            _contactService.TUpdate(new Contact()
            {
                Id = updateContactDTO.Id,
                Location = updateContactDTO.Location,
                Phone = updateContactDTO.Phone,
                Email = updateContactDTO.Email,
                FooterDescription = updateContactDTO.FooterDescription
            });
            return Ok("İletişim Güncellendi.");
        }

        [HttpGet("{id}")]
        public IActionResult GetContact(int id)
        {
            var contact = _contactService.TGetById(id);
            return Ok(contact);
        }
    }
}
