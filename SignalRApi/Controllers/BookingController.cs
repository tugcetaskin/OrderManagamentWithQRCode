using AutoMapper;
using BusinessLayer.Abstract;
using DTOLayer.AboutDTO;
using DTOLayer.BookingDTO;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly IMapper _mapper;

        public BookingController(IBookingService bookingService, IMapper mapper)
        {
            _bookingService = bookingService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult BookingList()
        {
            var values = _mapper.Map<List<ResultBookingDTO>>(_bookingService.TGetListAll());
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateBooking(CreateBookingDTO createBookingDTO)
        {
            _bookingService.TAdd(new Booking()
            {
                Email = createBookingDTO.Email,
                Date = createBookingDTO.Date,
                Name = createBookingDTO.Name,
                PersonCount = createBookingDTO.PersonCount,
                Phone = createBookingDTO.Phone,
            });
            return Ok("Rezervasyon Yapıldı.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
            var value = _bookingService.TGetById(id);
            _bookingService.TDelete(value);
            return Ok("Rezervasyon İptal Edildi.");
        }

        [HttpPut]
        public IActionResult UpdateBooking(UpdateBookingDTO updateBookingDTO)
        {
            _bookingService.TUpdate(new Booking()
            {
                Id = updateBookingDTO.Id,
                Email = updateBookingDTO.Email,
                Date = updateBookingDTO.Date,
                Name = updateBookingDTO.Name,
                PersonCount = updateBookingDTO.PersonCount,
                Phone = updateBookingDTO.Phone
            });
            return Ok("Rezervasyon Güncellendi.");
        }

        [HttpGet("{id}")]
        public IActionResult GetBooking(int id)
        {
            var value = _bookingService.TGetById(id);
            return Ok(value);
        }
    }
}
