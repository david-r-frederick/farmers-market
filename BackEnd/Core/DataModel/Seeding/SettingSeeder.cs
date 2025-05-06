using Core.DataModel.Entities;

namespace Core.DataModel.Seeding;

public class SettingSeeder : Seeder<Setting>
{
    public override List<string> GetSeedData() => ["SeedSampleProducts"];

    public override Setting MapCustomFieldsToSeedData(string seedKey, Setting setting)
    {
        switch (seedKey)
        {
            case "SeedSampleProducts":
                {
                    setting.Value = "true";
                    break;
                }
            default:
                {
                    setting.Value = "false";
                    break;
                }
        }
        return setting;
    }
}
