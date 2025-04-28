namespace Products.DataModel;

using AutoMapper;
using Products.DataModel.Entities;
using Products.DataModel.Models;

public class ProductMappingProfile : Profile
{
    public ProductMappingProfile()
    {
        CreateMap<Product, FullProductModel>()
            .ForMember(
                dest => dest.Categories,
                opt => opt.MapFrom(src => src.CategoryProducts
                    .Where(cp => cp.IsActive && cp.Category != null)
                    .Select(cp => cp.Category!)));

        CreateMap<Product, ListProductModel>();

        CreateMap<FullProductModel, Product>()
            .ForMember(dest => dest.CreatedOn, opt => opt.Ignore())
            .ForMember(dest => dest.IsDeleted, opt => opt.Ignore())
            .ForMember(dest => dest.IsActive, opt => opt.Ignore())
            .ForMember(dest => dest.CategoryProducts, opt => opt.Ignore()); // Ignore navigation property;
    }
}