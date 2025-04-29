namespace Categories.DataModel;

using AutoMapper;
using Categories.DataModel.Entities;
using Categories.DataModel.Models;

public sealed class CategoryMappingProfile : Profile
{
    public CategoryMappingProfile()
    {
        CreateMap<Category, FullCategoryModel>();

        CreateMap<FullCategoryModel, Category>()
            .ForMember(dest => dest.CreatedOn, opt => opt.Ignore())
            .ForMember(dest => dest.IsDeleted, opt => opt.Ignore())
            .ForMember(dest => dest.IsActive, opt => opt.Ignore());
    }
}
