using AutoMapper;
using DTOLayer.TestimonialDTO;
using EntityLayer.Entities;

namespace SignalRApi.Mapping
{
    public class TestimonialMapping : Profile
    {
        public TestimonialMapping() 
        { 
            CreateMap<Testimonial, ResultTestimonialDTO>().ReverseMap();
            CreateMap<Testimonial, GetTestimonialDTO>().ReverseMap();
            CreateMap<Testimonial, CreateTestimonialDTO>().ReverseMap();
            CreateMap<Testimonial, UpdateTestimonialDTO>().ReverseMap();
        }
    }
}
