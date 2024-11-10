using AutoMapper;
using BusinessLayer.Abstract;
using DTOLayer.TableDTO;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableForCustomersController : ControllerBase
    {
        private readonly ITableForCustomerService _tableForCustomerService;
        private readonly IMapper _mapper;

        public TableForCustomersController(ITableForCustomerService tableForCustomerService, IMapper mapper)
        {
            _tableForCustomerService = tableForCustomerService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult NumberOfTable()
        {
            return Ok(_tableForCustomerService.TTableCount());   
        }

        [HttpGet("{id}")]
        public IActionResult GetTableById(int id)
        {
            var value = _mapper.Map<GetTableDTO>(_tableForCustomerService.TGetById(id));
            return Ok(value);
        }

        [HttpGet("GetTableList")]
        public IActionResult GetTableList()
        {
            var values = _mapper.Map<List<ResultTableDTO>>(_tableForCustomerService.TGetListAll());
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateTable(CreateTableDTO table)
        {
            var value = _mapper.Map<TableForCustomer>(table);
            _tableForCustomerService.TAdd(value);
            return Ok("Masa Başarı İle Eklendi.");
        }

        [HttpPut]
        public IActionResult UpdateTable(UpdateTableDTO table)
        {
            var value = _mapper.Map<TableForCustomer>(table);
            _tableForCustomerService.TUpdate(value);
            return Ok("Masa Başarı İle Güncellendi.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTable(int id) 
        {
            var value = _tableForCustomerService.TGetById(id);
            _tableForCustomerService.TDelete(value);
            return Ok("Masa Başarı İle Silindi.");
        }

        [HttpGet("MarkAsAvailable/{id}")]
        public IActionResult MarkAsAvailable(int id)
        {
            _tableForCustomerService.TMarkAsAvaible(id);
            return Ok("Masa Müsait Olarak İşaretlendi.");
        }

        [HttpGet("MarkAsFull/{id}")]
        public IActionResult MarkAsFull(int id)
        {
            _tableForCustomerService.TMarkAsFull(id);
            return Ok("Masa Müsait Değil Olarak İşaretlendi.");
        }

        [HttpGet("TableId/{name}")]
        public IActionResult TableId(string name)
        {
            var id = _tableForCustomerService.TGetTableIDByName(name);
            return Ok(id);
        }

        [HttpGet("NewTableNumber")]
        public IActionResult NewTableNumber()
        {
            var num = _tableForCustomerService.TNewTableId();
            return Ok(num);
        }

        [HttpGet("AvailableOnlineTable")]
        public IActionResult AvailableOnlineTable()
        {
            var table = _tableForCustomerService.TAvailableOnlineTable();
            return Ok(table);
        }
	}
}
