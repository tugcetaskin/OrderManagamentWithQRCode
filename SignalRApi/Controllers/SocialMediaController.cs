using AutoMapper;
using BusinessLayer.Abstract;
using DTOLayer.AboutDTO;
using DTOLayer.SocialMediaDTO;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly ISocialMediaService _socialMediaService;
        private readonly IMapper _mapper;

        public SocialMediaController(ISocialMediaService socialMediaService, IMapper mapper)
        {
            _socialMediaService = socialMediaService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult SocialMediaList()
        {
            var values = _mapper.Map<List<ResultSocialMediaDTO>>(_socialMediaService.TGetListAll());
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateSocialMedia(CreateSocialMediaDTO socialMediaDTO)
        {
            _socialMediaService.TAdd(new SocialMedia()
            {
                Title = socialMediaDTO.Title,
                Url = socialMediaDTO.Url,
                Icon = socialMediaDTO.Icon
            });
            return Ok("Sosyal Medya Başarılı Bir Şekilde Eklendi");
        }

        [HttpPut]
        public IActionResult UpdateSocialMedia(UpdateSocialMediaDTO socialMediaDTO)
        {
            _socialMediaService.TUpdate(new SocialMedia()
            {
                Id = socialMediaDTO.Id,
                Title = socialMediaDTO.Title,
                Url = socialMediaDTO.Url,
                Icon = socialMediaDTO.Icon
            });
            return Ok("Sosyal Medya Güncellendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSocialMedia(int id)
        {
            var value = _socialMediaService.TGetById(id);
            _socialMediaService.TDelete(value);
            return Ok("Sosyal Medya Silindi");
        }

        [HttpGet("{id}")]
        public IActionResult GetSocialMedia(int id)
        {
            var value = _socialMediaService.TGetById(id);
            return Ok(value);
        }
    }
}
