namespace Users.DataModel.Entities;

using System.ComponentModel.DataAnnotations;

public partial class Role
{
    [Key]
    public int Id { get; set; }

    public string Key { get; set; } = null!;

    public string Name { get; set; } = null!;
}
