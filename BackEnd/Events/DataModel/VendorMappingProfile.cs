namespace Events.DataModel;

using AutoMapper;
using Customers.DataModel.Models;
using Events.DataModel.Models;

public class VendorMappingProfile : Profile
{
    public VendorMappingProfile()
    {
        CreateMap<RegisterAsVendorForm, FullUserModel>()
            .ForMember(dest => dest.PostalCode, opt => opt.MapFrom(src => src.ZipCode));
    }
}
