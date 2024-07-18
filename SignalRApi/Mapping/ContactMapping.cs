using AutoMapper;
using DTOLayer.ContactDTO;
using EntityLayer.Entities;

namespace SignalRApi.Mapping
{
    public class ContactMapping :Profile
    {
        public ContactMapping() 
        {
            CreateMap<Contact, ResultContactDTO>().ReverseMap();
            CreateMap<Contact, CreateContactDTO>().ReverseMap();
            CreateMap<Contact, GetContactDTO>().ReverseMap();
            CreateMap<Contact, UpdateContactDTO>().ReverseMap();
        }
    }
}
