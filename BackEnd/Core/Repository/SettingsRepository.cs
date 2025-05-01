using AutoMapper;
using Core.Entities;
using Core.Models;

namespace Core.Repository;

public class SettingsRepository : Repository<Setting, SettingModel, SettingModel>, ISettingsRepository
{
    public SettingsRepository(
        IDbContextFactoryWrapper dbFactory,
        IMapper mapper) : base(dbFactory, mapper)
    {
    }
}
