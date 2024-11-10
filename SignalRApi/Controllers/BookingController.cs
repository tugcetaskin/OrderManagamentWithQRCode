using AutoMapper;
using BusinessLayer.Abstract;
using DTOLayer.AboutDTO;
using DTOLayer.BookingDTO;
using EntityLayer.Entities;
using FluentValidation;
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
        private readonly IValidator<CreateBookingDTO> _validator;

        public BookingController(IBookingService bookingService, IMapper mapper, IValidator<CreateBookingDTO> validator)
        {
            _bookingService = bookingService;
            _mapper = mapper;
            _validator = validator;
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
            var validationResult = _validator.Validate(createBookingDTO);
            if(!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            var value = _mapper.Map<Booking>(createBookingDTO);
            _bookingService.TAdd(value);
            return Ok("Rezervasyon Oluşturuldu.");
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
            var value = _mapper.Map<Booking>(updateBookingDTO);
            _bookingService.TUpdate(value);
            return Ok("Rezervasyon Güncellendi.");
        }

        [HttpGet("{id}")]
        public IActionResult GetBooking(int id)
        {
            var value = _mapper.Map<GetBookingDTO>(_bookingService.TGetById(id));
            return Ok(value);
        }

        [HttpGet("Cancel/{id}")]
        public IActionResult CancelRezervation(int id) 
        {
            _bookingService.TCancelRezervation(id);
            return Ok("Rezervasyon İptal Edildi");
        }

        [HttpGet("Confirm/{id}")]
        public IActionResult ConfirmRezervation(int id)
        {
            _bookingService.TConfirmRezervation(id);
            return Ok("Rezervasyon Onaylandı");
        }
    }
}
