using AutoMapper;
using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableForCustomersController : ControllerBase
    {
        private readonly ITableForCustomerService tableForCustomerService;
        private readonly IMapper mapper;

        public TableForCustomersController(ITableForCustomerService tableForCustomerService, IMapper mapper)
        {
            this.tableForCustomerService = tableForCustomerService;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult NumberOfTable()
        {
            return Ok(tableForCustomerService.TTableCount());   
        }
    }
}
