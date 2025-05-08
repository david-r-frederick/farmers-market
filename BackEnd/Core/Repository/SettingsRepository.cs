using AutoMapper;
using Core.DataModel.Entities;
using Core.DataModel.Models;
using Microsoft.AspNetCore.Http;

namespace Core.Repository;

public class SettingsRepository : Repository<Setting, SettingModel, SettingModel>, ISettingsRepository
{
    public SettingsRepository(
        IDbContextFactoryWrapper dbFactory,
        IMapper mapper,
        IHttpContextAccessor httpContextAccessor) : base(dbFactory, mapper, httpContextAccessor)
    {
    }
}
