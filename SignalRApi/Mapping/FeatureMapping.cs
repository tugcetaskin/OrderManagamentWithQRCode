using AutoMapper;
using DTOLayer.FeatureDTO;
using EntityLayer.Entities;

namespace SignalRApi.Mapping
{
    public class FeatureMapping : Profile
    {
        public FeatureMapping() 
        {
            CreateMap<Feature, ResultFeatureDTO>().ReverseMap();
            CreateMap<Feature, CreateFeatureDTO>().ReverseMap();
            CreateMap<Feature, GetFeatureDTO>().ReverseMap();
            CreateMap<Feature, UpdateFeatureDTO>().ReverseMap();
        }
    }
}
