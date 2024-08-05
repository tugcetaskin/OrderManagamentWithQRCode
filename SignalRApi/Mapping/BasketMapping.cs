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
            CreateMap<Basket, GetBasketDTO>().ReverseMap();
            CreateMap<Basket, CreateBasketDTO>().ReverseMap();
            CreateMap<Basket, UpdateBasketDTO>().ReverseMap();
            CreateMap<Basket, ResultBasketDTO>().ReverseMap();
        }
    }
}
