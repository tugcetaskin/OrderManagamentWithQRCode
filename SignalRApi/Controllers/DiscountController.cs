using AutoMapper;
using BusinessLayer.Abstract;
using DTOLayer.DiscountDTO;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        private readonly IMapper _mapper;

        public DiscountController(IDiscountService discountService, IMapper mapper)
        {
            _discountService = discountService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult DiscountList()
        {
            var values = _mapper.Map<List<ResultDiscountDTO>>(_discountService.TGetListAll());
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateDiscount(CreateDiscountDTO discountDTO)
        {
            var value = _mapper.Map<Discount>(discountDTO);
            _discountService.TAdd(value);
            return Ok("İndirim Başarılı Bir Şekilde Eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDiscount(int id)
        {
            var value = _discountService.TGetById(id);
            _discountService.TDelete(value);
            return Ok("İndirim Silindi");
        }

        [HttpPut]
        public IActionResult UpdateDiscount(UpdateDiscountDTO discountDTO)
        {
            var value = _mapper.Map<Discount>(discountDTO);
            _discountService.TUpdate(value);
            return Ok("İndirim Güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetDiscount(int id)
        {
            var value = _mapper.Map<GetDiscountDTO>(_discountService.TGetById(id));
            return Ok(value);
        }

        [HttpGet("ChangeStatus/{id}")]
        public IActionResult ChangeStatus(int id)
        {
            _discountService.TChangeStatus(id);
            return Ok("İndirim Durumu Değiştirildi.");
        }

        [HttpGet("GetLastTwo")]
        public IActionResult GetLastTwo()
        {
            var values = _mapper.Map<List<ResultDiscountDTO>>(_discountService.TGetLastTwo());
            return Ok(values);
        }
    }
}
