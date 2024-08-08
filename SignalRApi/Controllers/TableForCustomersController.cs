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
            var value = _tableForCustomerService.TGetById(id);
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
            _tableForCustomerService.TAdd(new TableForCustomer()
            {
                Name = table.Name,
                Status = table.Status,
                TableFor = table.TableFor
            });
            return Ok("Masa Başarı İle Eklendi.");
        }

        [HttpPut]
        public IActionResult UpdateTable(UpdateTableDTO table)
        {
            var value = _tableForCustomerService.TGetById(table.Id);
            value.Status = table.Status;
            value.Name = table.Name;
            value.TableFor = table.TableFor;
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
    }
}
