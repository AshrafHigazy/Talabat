using AutoMapper;
using DomanLayer.Models;
using Shared.DTOs.ProducrDTOs;


namespace ServiceLayer.MappingProfiles
{
    public class productProfile : Profile
    {
        public productProfile()
        {
            CreateMap<Product, ProductDTO>()
                .ForMember(dest => dest.BrandName, options => options.MapFrom(src => src.ProductBrand.Name))
                                .ForMember(dest => dest.TypeName, options => options.MapFrom(src => src.ProductType.Name))
                                .ForMember(dest => dest.PictureUrl, options => options.MapFrom<PictureUrlResolver>());

            CreateMap<ProductType, TypeDTO>();
            CreateMap<ProductBrand, BrandDTO>();

        }

    }
}
