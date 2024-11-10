using AutoMapper;
using BusinessLayer.Abstract;
using DTOLayer.SliderDTO;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SlidersController : ControllerBase
    {
        private readonly ISliderService _sliderService;
        private readonly IMapper _mapper;

        public SlidersController(ISliderService sliderService, IMapper mapper)
        {
            _sliderService = sliderService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> SliderList()
        {
            var values = _mapper.Map<List<ResultSliderDTO>>(_sliderService.TGetListAll());
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSlider(CreateSliderDTO sliderDto)
        {
            var value = _mapper.Map<Slider>(sliderDto);
            _sliderService.TAdd(value);
            return Ok("Slider Başarıyla Eklendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSlider(int id)
        {
            var slider = _sliderService.TGetById(id);
            if(slider == null)
            {
                return BadRequest();
            }
            _sliderService.TDelete(slider);
            return Ok("Slider Alanı Silindi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSlider(UpdateSliderDTO sliderDto)
        {
            var value = _mapper.Map<Slider>(sliderDto);
            _sliderService.TUpdate(value);
            return Ok("Slider Başarıyla Güncellendi.");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSlider(int id)
        {
            var slider = _mapper.Map<GetSliderDTO>(_sliderService.TGetById(id));
            return Ok(slider);
        }
    }
}
