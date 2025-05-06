namespace Core.DataModel.Entities;

[SQLTable("System", "LogType")]
public class LogType : BaseEntity
{
    public string Name { get; set; } = null!;
}
