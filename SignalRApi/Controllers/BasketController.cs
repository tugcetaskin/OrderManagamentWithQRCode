using AutoMapper;
using BusinessLayer.Abstract;
using DTOLayer.BasketDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly IMapper _mapper;

        public BasketController(IBasketService basketService, IMapper mapper)
        {
            _basketService = basketService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetBasketByTable(int id)
        {
            var value = _mapper.Map<List<ResultBasketByTableDTO>>(_basketService.TGetBasketByTableNum(id));
            return Ok(value);
        }
    }
}
