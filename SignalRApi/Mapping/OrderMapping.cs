using AutoMapper;
using DTOLayer.OrderDetailDTO;
using DTOLayer.OrderDTO;
using EntityLayer.Entities;

namespace SignalRApi.Mapping
{
    public class OrderMapping : Profile
    {
        public OrderMapping()
        {
            CreateMap<Order, ResultOrderDTO>().ReverseMap();
            CreateMap<Order, CreateOrderDTO>().ReverseMap();
            CreateMap<Order, GetOrderDTO>().ReverseMap();
            CreateMap<Order, UpdateOrderDTO>().ReverseMap();
        }
    }
}
