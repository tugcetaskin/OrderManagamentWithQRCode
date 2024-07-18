using AutoMapper;
using DTOLayer.BookingDTO;
using EntityLayer.Entities;

namespace SignalRApi.Mapping
{
    public class BookingMapping : Profile
    {
        public BookingMapping()
        {
            CreateMap<Booking, ResultBookingDTO>().ReverseMap();
            CreateMap<Booking, CreateBookingDTO>().ReverseMap();
            CreateMap<Booking, GetBookingDTO>().ReverseMap();
            CreateMap<Booking, UpdateBookingDTO>().ReverseMap();
        }
    }
}
