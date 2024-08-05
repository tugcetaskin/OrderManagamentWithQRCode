using AutoMapper;
using BusinessLayer.Abstract;
using DTOLayer.AboutDTO;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;
        private readonly IMapper _mapper;

        public AboutController(IAboutService aboutService, IMapper mapper)
        {
            _aboutService = aboutService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult AboutList()
        {
            var values = _mapper.Map<List<ResultAboutDTO>>(_aboutService.TGetListAll());
            return Ok(values);
        }

        [HttpGet("GetLastAbout")]
        public IActionResult GetLastAbout()
        {
            return Ok(_aboutService.TGetLastAbout());
        }

        [HttpPost]
        public IActionResult CreateAbout(CreateAboutDTO createAboutDTO)
        {
            _aboutService.TAdd(new About()
            {
                Title = createAboutDTO.Title,
                Description = createAboutDTO.Description,
                ImageUrl = createAboutDTO.ImageUrl
            });
            return Ok("Hakkımda Kısmı Başarılı Bir Şekilde Eklendi.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAbout(int id)
        {
            var value = _aboutService.TGetById(id);
            _aboutService.TDelete(value);
            return Ok("Hakkımda Alanı Silindi.");
        }

        [HttpPut]
        public IActionResult UpdateAbout(UpdateAboutDTO updateAboutDTO)
        {
            _aboutService.TUpdate(new About()
            {
                Id = updateAboutDTO.Id,
                Title = updateAboutDTO.Title,
                Description = updateAboutDTO.Description,
                ImageUrl = updateAboutDTO.ImageUrl
            });
            return Ok("Hakkımda Alanı Güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetAbout(int id)
        {
            var value = _aboutService.TGetById(id);
            return Ok(value);
        }
    }
}
