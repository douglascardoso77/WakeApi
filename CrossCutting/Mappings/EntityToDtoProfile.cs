using AutoMapper;
using Domain.Dtos.Product;
using Domain.Entities;

namespace CrossCutting.Mappings
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            CreateMap<ProductDto, ProductEntity>()
                .ReverseMap();

            CreateMap<ProductCreateResult, ProductEntity>()
                .ReverseMap();

            CreateMap<ProductUpdatedResult, ProductEntity>()
                .ReverseMap();
        }
    }
}