using AutoMapper;
using Domain.Dtos.Product;
using Domain.Models;

namespace CrossCutting.Mappings
{
    public class DtoToModelProfile : Profile
    {
        public DtoToModelProfile()
        {
            CreateMap<ProductModel, ProductDto>()
                .ReverseMap();
            CreateMap<ProductModel, ProductDtoCreate>()
                .ReverseMap(); 
            CreateMap<ProductModel, ProductDtoUpdate>()
                .ReverseMap();
        }
    }
}