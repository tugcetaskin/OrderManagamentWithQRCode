using AutoMapper;
using BusinessLayer.Abstract;
using DTOLayer.OrderDTO;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrdersController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult OrderList()
        {
            var values = _mapper.Map<List<ResultOrderDTO>>(_orderService.TGetListAll());
            return Ok(values);
        }

        [HttpGet("TodaysEarningsAmount")]
        public IActionResult TodaysEarningsAmount()
        {
            return Ok(_orderService.TTodaysEarningsAmount());
        }

        [HttpGet("TotalOrderCount")]
        public IActionResult TotalOrderCount()
        {
            return Ok(_orderService.TTotalOrderCount());
        }

        [HttpGet("ActiveOrderCount")]
        public IActionResult ActiveOrderCount()
        {
            return Ok(_orderService.TActiveOrderCount());
        }

        [HttpPost]
        public IActionResult CreateOrder(CreateOrderDTO dto)
        {
            _orderService.TAdd(new Order()
            {
                TableNumber = dto.TableNumber,
                Description = dto.Description,
                Date = DateTime.Now,
                TotalPrice = dto.TotalPrice,
                OrderDetail = dto.OrderDetail,
            });
            return Ok("Sipariş Eklendi.");
        }
    }
}
