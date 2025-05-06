using AutoMapper;
using Core.DataModel.Entities;
using Core.DataModel.Models;

namespace Core.Mapping;

public class BaseMappingProfile : Profile
{
    public BaseMappingProfile()
    {
        CreateMap<IBaseEntity, BaseModel>().IncludeAllDerived();
    }
}