using AutoMapper;
using BusinessLayer.Abstract;
using DTOLayer.TestimonialDTO;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;
        private readonly IMapper _mapper;

        public TestimonialController(ITestimonialService testimonialService, IMapper mapper)
        {
            _testimonialService = testimonialService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult TestimonialList()
        {
            var values = _mapper.Map<List<ResultTestimonialDTO>>(_testimonialService.TGetListAll());
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateTestimonial(CreateTestimonialDTO testimonialDTO)
        {
            var value = _mapper.Map<Testimonial>(testimonialDTO);
            _testimonialService.TAdd(value);
            return Ok("Referans Başarılı Bir Şekilde Eklendi");
        }

        [HttpPut]
        public IActionResult UpdateTestimonial(UpdateTestimonialDTO testimonialDTO)
        {
            var value = _mapper.Map<Testimonial>(testimonialDTO);
            _testimonialService.TUpdate(value);
            return Ok("Referans Güncellendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTestimonial(int id)
        {
            var value = _testimonialService.TGetById(id);
            _testimonialService.TDelete(value);
            return Ok("Referans Silindi");
        }

        [HttpGet("{id}")]
        public IActionResult GetTestimonial(int id)
        {
            var value = _mapper.Map<GetTestimonialDTO>(_testimonialService.TGetById(id));
            return Ok(value);
        }
    }
}
