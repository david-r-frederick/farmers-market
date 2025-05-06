namespace Customers.DataModel.Entities;

using Core;
using Core.Entities;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[SQLTable("Auth", "Role")]
public partial class Role : IdentityRole<int>, IBaseEntity
{
    [Key]
    [Column(Order = 1)]
    public override int Id { get; set; }

    [Column(Order = 2)]
    public virtual string? Key { get; set; }

    [Column(Order = 4), DefaultValue(true)]
    public virtual bool IsActive { get; set; }

    [Column(Order = 5)]
    public virtual DateTime CreatedOn { get; set; }

    [Column(Order = 6)]
    public virtual string? CreatedBy { get; set; }

    [Column(Order = 7)]
    public virtual string? UpdatedBy { get; set; }

    [Column(Order = 8)]
    public virtual DateTime? UpdatedOn { get; set; }

    [Column(Order = 9), DefaultValue(false)]
    public virtual bool IsDeleted { get; set; }

    [Column(Order = 10)]
    public virtual DateTime? DeletedOn { get; set; }

    [Column(Order = 11)]
    public virtual string? DeletedBy { get; set; }
}
