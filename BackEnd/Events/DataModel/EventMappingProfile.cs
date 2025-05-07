namespace Events.DataModel;

using AutoMapper;
using Events.DataModel.Models;

public class EventMappingProfile : Profile
{
    public EventMappingProfile()
    {
        CreateMap<CreateEventForm, FullEventModel>()
            .ForMember(dest => dest.HostUserId, opt => opt.Ignore())
            .ForMember(dest => dest.AddressId, opt => opt.MapFrom(src => src.Address.Id));
    }
}
