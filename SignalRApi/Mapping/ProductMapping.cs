using AutoMapper;
using DTOLayer.ProductDTO;
using EntityLayer.Entities;

namespace SignalRApi.Mapping
{
    public class ProductMapping : Profile
    {
        public ProductMapping() 
        {
            CreateMap<Product, ResultProductDTO>().ReverseMap();
            CreateMap<Product, ResultProductWithCategory>().ReverseMap();
            CreateMap<Product, GetProductDTO>().ReverseMap();
            CreateMap<Product, CreateProductDTO>().ReverseMap();
            CreateMap<Product, UpdateProductDTO>().ReverseMap();
        }
    }
}
