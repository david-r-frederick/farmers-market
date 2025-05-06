using AutoMapper;
using Core.DataModel.Entities;
using Core.DataModel.Models;

namespace Core.Repository;

public class SettingsRepository : Repository<Setting, SettingModel, SettingModel>, ISettingsRepository
{
    public SettingsRepository(
        IDbContextFactoryWrapper dbFactory,
        IMapper mapper) : base(dbFactory, mapper)
    {
    }
}
