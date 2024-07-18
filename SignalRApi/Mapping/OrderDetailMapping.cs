using AutoMapper;
using DTOLayer.OrderDetailDTO;
using EntityLayer.Entities;

namespace SignalRApi.Mapping
{
    public class OrderDetailMapping : Profile
    {
        public OrderDetailMapping()
        {
            CreateMap<OrderDetail, ResultOrderDetailDTO>().ReverseMap();
            CreateMap<OrderDetail, CreateOrderDetailDTO>().ReverseMap();
            CreateMap<OrderDetail, GetOrderDetailDTO>().ReverseMap();
            CreateMap<OrderDetail, UpdateOrderDetailDTO>().ReverseMap();
        }
    }
}
