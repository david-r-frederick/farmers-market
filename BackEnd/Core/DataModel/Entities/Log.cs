namespace Core.DataModel.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[SQLTable("System", "SystemLog")]
public class Log
{
    [Key]
    [Column(Order = 0)]
    public int Id { get; set; }

    [Column(Order = 1)]
    public virtual string Key { get; set; } = string.Empty;

    [Column(Order = 2)]
    public virtual DateTime CreatedOn { get; set; }

    [Column(Order = 3)]
    public string Description { get; set; } = null!;

    [Column(Order = 4)]
    public string MethodName { get; set; } = null!;

    public string? StackTrace { get; set; } = null!;

    public int? UserID { get; set; }

    public string? RequestPath { get; set; }

    public required int TypeId { get; set; }

    public virtual LogType? Type { get; set; }

}
