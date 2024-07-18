using AutoMapper;
using BusinessLayer.Abstract;
using DTOLayer.DiscountDTO;
using DTOLayer.FeatureDTO;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly IFeatureService _featureService;
        private readonly IMapper _mapper;

        public FeatureController(IFeatureService featureService, IMapper mapper)
        {
            _featureService = featureService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult FeatureList()
        {
            var values = _mapper.Map<List<ResultFeatureDTO>>(_featureService.TGetListAll());
            return Ok(values);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFeature(int id)
        {
            var feature = _featureService.TGetById(id);
            _featureService.TDelete(feature);
            return Ok("Öne Çıkan Alanı Silindi");
        }

        [HttpPost]
        public IActionResult CreateFeature(CreateFeatureDTO featureDTO)
        {
            _featureService.TAdd(new Feature()
            {
                Title1 = featureDTO.Title1,
                Description1 = featureDTO.Description1,
                Title2 = featureDTO.Title2,
                Description2 = featureDTO.Description2,
                Title3 = featureDTO.Title3,
                Description3 = featureDTO.Description3
            });
            return Ok("Öne Çıkan Alanı Başarılı Bir Şekilde Eklendi");
        }

        [HttpPut]
        public IActionResult UpdateFeature(UpdateFeatureDTO featureDTO)
        {
            _featureService.TUpdate(new Feature()
            {
                Id = featureDTO.Id,
                Title1 = featureDTO.Title1,
                Description1 = featureDTO.Description1,
                Title2 = featureDTO.Title2,
                Description2 = featureDTO.Description2,
                Title3 = featureDTO.Title3,
                Description3 = featureDTO.Description3
            });
            return Ok("Öne Çıkan Alanı Güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetFeature(int id)
        {
            var value = _featureService.TGetById(id);
            return Ok(value);
        }
    }
}
