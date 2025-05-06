namespace Customers.DataModel;

using AutoMapper;
using Customers.DataModel.Entities;
using Customers.DataModel.Models;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<FullUserModel, User>()
            .ForMember(dest => dest.PostalCode, opt => opt.MapFrom(src => src.PostalCode))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.NormalizedEmail, opt => opt.Ignore())
            .ForMember(dest => dest.NormalizedUserName, opt => opt.Ignore())
            .ForMember(dest => dest.PasswordHash, opt => opt.Ignore())
            .ForMember(dest => dest.SecurityStamp, opt => opt.Ignore())
            .ForMember(dest => dest.ConcurrencyStamp, opt => opt.Ignore())
            .ForMember(dest => dest.PhoneNumber, opt => opt.Ignore()) // if not set in FullUserModel
            .ForMember(dest => dest.Roles, opt => opt.Ignore());

        CreateMap<User, FullUserModel>()
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.PostalCode, opt => opt.MapFrom(src => src.PostalCode));
    }
}
