using AutoMapper;
using DTOLayer.TableDTO;
using EntityLayer.Entities;

namespace SignalRApi.Mapping
{
    public class TableMapping : Profile
    {
        public TableMapping() 
        {
            CreateMap<TableForCustomer, ResultTableDTO>().ReverseMap();
            CreateMap<TableForCustomer, GetTableDTO>().ReverseMap();
            CreateMap<TableForCustomer, UpdateTableDTO>().ReverseMap();
            CreateMap<TableForCustomer, CreateTableDTO>().ReverseMap();
        }
    }
}
