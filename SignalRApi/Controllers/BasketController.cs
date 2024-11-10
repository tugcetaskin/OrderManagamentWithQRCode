using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using DTOLayer.BasketDTO;
using EntityLayer.Entities;
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
        [HttpPost]
        public IActionResult AddBasket(CreateBasketDTO basket)
        {
            using var _context = new Context();
            var product = _context.Products.Where(z => z.Id == basket.ProductId).FirstOrDefault();
            var table = _context.TableForCustomers.Where(t => t.Id == basket.TableId).FirstOrDefault();

            _basketService.TAdd(new Basket()
            {
                ProductId = basket.ProductId,
                TableId = basket.TableId,
                Count = 1,
                Price = product.Price,
                TotalPrice = product.Price
            });

            return Ok($"{product.Name} Sepete Başarı İle Eklendi.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBasket(int id)
        {
            var value = _basketService.TGetById(id);
            _basketService.TDelete(value);
            return Ok("Seçilen Ürün Başarı İle Silindi");
        }

		[HttpGet("GetBasketByProductAndTable")]
		public IActionResult GetBasketByProductAndTable(int productId, int tableID)
		{
			var value = _basketService.TGetBasketByProductAndTable(productId, tableID);
			if (value == null)
			{
				return NotFound("Basket not found");
			}

			GetBasketDTO basketDTO = new GetBasketDTO()
			{
				Id = value.Id,
				ProductId = value.ProductId,
				TableId = value.TableId,
				Count = value.Count,
				Price = value.Price,
				TotalPrice = value.Price,
				Product = value.Product,
				Table = value.Table
			};
			return Ok(basketDTO);
		}

        [HttpGet("BasketIdByProductAndTable")]
        public IActionResult BasketIdByPAndT(int productId, int tableID)
        {
            var id = _basketService.TGetBasketIdByPAndT(productId, tableID);
            return Ok(id);
        }

		[HttpGet("BasketIdByTable")]
		public IActionResult BasketIdByTable(int tableID)
		{
            var id = _basketService.TGetBasketIdByTable(tableID);
			return Ok(id);
		}

	}
}
