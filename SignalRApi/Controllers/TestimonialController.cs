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
            _testimonialService.TAdd(new Testimonial()
            {
                Name = testimonialDTO.Name,
                Title = testimonialDTO.Title,
                Comment = testimonialDTO.Comment,
                ImageUrl = testimonialDTO.ImageUrl,
                Status = testimonialDTO.Status
            });
            return Ok("Referans Başarılı Bir Şekilde Eklendi");
        }

        [HttpPut]
        public IActionResult UpdateTestimonial(UpdateTestimonialDTO testimonialDTO)
        {
            _testimonialService.TUpdate(new Testimonial()
            {
                Id = testimonialDTO.Id,
                Name = testimonialDTO.Name,
                Title = testimonialDTO.Title,
                Comment = testimonialDTO.Comment,
                ImageUrl = testimonialDTO.ImageUrl,
                Status = testimonialDTO.Status
            });
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
            var value = _testimonialService.TGetById(id);
            return Ok(value);
        }
    }
}
