using AutoMapper;
using DTOLayer.BasketDTO;
using EntityLayer.Entities;

namespace SignalRApi.Mapping
{
    public class BasketMapping : Profile
    {
        public BasketMapping()
        {
            CreateMap<Basket, ResultBasketByTableDTO>().ReverseMap();
            CreateMap<Basket, GetBasketByPAndTDTO>().ReverseMap();
            CreateMap<Basket, CreateBasketDTO>().ReverseMap();
            CreateMap<Basket, UpdateBasketDTO>().ReverseMap();
            CreateMap<Basket, ResultBasketDTO>().ReverseMap();
        }
    }
}
