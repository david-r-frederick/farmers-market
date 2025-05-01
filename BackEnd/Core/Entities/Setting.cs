namespace Core.Entities;

[SQLTable("Core", "Setting")]
public class Setting : BaseEntity
{
    public string Value { get; set; } = null!;
}