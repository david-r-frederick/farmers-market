namespace Core.Repository;

using Core.DataModel.Entities;
using Core.DataModel.Models;

public class SettingsRepository : Repository<Setting, SettingModel, SettingModel>, ISettingsRepository
{
}
