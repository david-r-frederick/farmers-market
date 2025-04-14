namespace Entities.Core;

using Entities.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Index(nameof(Id))]
[Index(nameof(IsActive))]
[Index(nameof(IsDeleted))]
public abstract class BaseEntity : IBaseEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column(Order = 0)]
    public virtual int Id { get; set; }

    [Column(Order = 1)]
    public virtual string? Key { get; set; }

    [DefaultValue(true)]
    [Column(Order = 2)]
    public virtual bool IsActive { get; set; }

    [Column(Order = 3)]
    public virtual string? CreatedBy { get; set; }

    [Column(Order = 4)]
    public virtual DateTime CreatedOn { get; set; }

    [DefaultValue(false)]
    [Column(Order = 5)]
    public virtual bool IsDeleted { get; set; }

    [Column(Order = 6)]
    public virtual string? DeletedBy { get; set; }

    [Column(Order = 7)]
    public virtual DateTime? DeletedOn { get; set; }

    [Column(Order = 8)]
    public virtual string? UpdatedBy { get; set; }

    [Column(Order = 9)]
    public virtual DateTime? UpdatedOn { get; set; }
}
