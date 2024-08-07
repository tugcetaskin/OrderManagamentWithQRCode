using AutoMapper;
using DTOLayer.NotificationDTO;
using EntityLayer.Entities;

namespace SignalRApi.Mapping
{
    public class NotificationMapping : Profile
    {
        public NotificationMapping() 
        {
            CreateMap<Notification, CreateNotificationDTO>().ReverseMap();
            CreateMap<Notification, UpdateNotificationDTO>().ReverseMap();
            CreateMap<Notification, GetNotificationDTO>().ReverseMap();
            CreateMap<Notification, ResultNotificationDTO>().ReverseMap();
        }
    }
}
