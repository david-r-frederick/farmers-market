namespace Entities.Core;

using System.ComponentModel.DataAnnotations;

[SQLTable("Auth", "Role")]
public partial class Role
{
    [Key]
    public int Id { get; set; }

    public string Key { get; set; } = null!;

    public string Name { get; set; } = null!;
}
