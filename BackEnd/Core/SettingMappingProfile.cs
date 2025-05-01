namespace Core;

using AutoMapper;
using Core.Entities;
using Core.Models;

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