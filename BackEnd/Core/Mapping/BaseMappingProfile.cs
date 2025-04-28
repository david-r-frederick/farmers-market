using AutoMapper;
using Core.Entities;
using Core.Models;

namespace Core.Mapping;

public class BaseMappingProfile : Profile
{
    public BaseMappingProfile()
    {
        CreateMap<IBaseEntity, BaseModel>().IncludeAllDerived();
    }
}