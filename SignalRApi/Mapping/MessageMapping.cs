using AutoMapper;
using DTOLayer.MessageDTO;
using EntityLayer.Entities;

namespace SignalRApi.Mapping
{
    public class MessageMapping : Profile
    {
        public MessageMapping() 
        { 
            CreateMap<ResultMessageDTO, Message>().ReverseMap();
            CreateMap<CreateMessageDTO, Message>().ReverseMap();
            CreateMap<GetMessageDTO, Message>().ReverseMap();
            CreateMap<UpdateMessageDTO, Message>().ReverseMap();
        }
    }
}
