using AutoMapper;
using Domain.Entities;
using Domain.Models;

namespace CrossCutting.Mappings
{
    public class ModelToEntityProfile : Profile
    {
            public ModelToEntityProfile()
            {
                CreateMap<ProductEntity, ProductModel>()
                    .ReverseMap();
            }
    }
}