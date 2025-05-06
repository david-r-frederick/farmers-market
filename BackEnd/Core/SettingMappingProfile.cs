namespace Core;

using AutoMapper;
using Core.DataModel.Entities;
using Core.DataModel.Models;

public class SettingMappingProfile : Profile
{
    public SettingMappingProfile()
    {
        CreateMap<Setting, SettingModel>();

        CreateMap<SettingModel, Setting>()
            .ForMember(dest => dest.CreatedOn, opt => opt.Ignore())
            .ForMember(dest => dest.IsDeleted, opt => opt.Ignore())
            .ForMember(dest => dest.IsActive, opt => opt.Ignore());
    }
}