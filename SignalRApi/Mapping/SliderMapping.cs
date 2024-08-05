using AutoMapper;
using DTOLayer.SliderDTO;
using EntityLayer.Entities;

namespace SignalRApi.Mapping
{
    public class SliderMapping : Profile
    {
        public SliderMapping() 
        {
            CreateMap<Slider, ResultSliderDTO>().ReverseMap();
            CreateMap<Slider, UpdateSliderDTO>().ReverseMap();
            CreateMap<Slider, CreateSliderDTO>().ReverseMap();
            CreateMap<Slider, GetSliderDTO>().ReverseMap();
        }
    }
}
