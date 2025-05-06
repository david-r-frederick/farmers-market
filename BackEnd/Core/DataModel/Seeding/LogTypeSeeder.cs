namespace Core.DataModel.Seeding;

using Core.DataModel.Entities;

public class LogTypeSeeder : Seeder<LogType>
{
    public override List<string> GetSeedData() => ["Info", "Error"];

    public override LogType MapCustomFieldsToSeedData(string seedKey, LogType logType)
    {
        logType.Name = seedKey;
        return logType;
    }
}
