namespace Customers.DataModel.Entities;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Core;
using Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

[SQLTable("Auth", "User")]
[Index(nameof(Id))]
[Index(nameof(IsActive))]
[Index(nameof(IsDeleted))]
[Index(nameof(LastName))]
[Index(nameof(FirstName))]
public partial class User : IdentityUser<int>, IBaseEntity
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

    [JsonIgnore]
    public override string? PasswordHash { get => base.PasswordHash; set => base.PasswordHash = value; }

    /// <inheritdoc/>
    [JsonIgnore]
    public override string? SecurityStamp { get => base.SecurityStamp; set => base.SecurityStamp = value; }

    /// <inheritdoc/>
    [JsonIgnore]
    public override string? ConcurrencyStamp { get => base.ConcurrencyStamp; set => base.ConcurrencyStamp = value; }

    [Required(ErrorMessage = "First name is required")]
    [MaxLength(100)]
    [Display(Name = "First Name")]
    public required string FirstName { get; set; }

    [MaxLength(1)]
    [Display(Name = "MI")]
    [Column("MiddleInitial")]
    public string? MiddleInitial { get; set; }

    [Required(ErrorMessage = "Last name is required")]
    [MaxLength(100)]
    [Display(Name = "Last Name")]
    public required string LastName { get; set; }

    [MaxLength(200)]
    [Display(Name = "Street Address")]
    public required string Street1 { get; set; }

    [MaxLength(200)]
    [Display(Name = "Address Line 2")]
    public string? Street2 { get; set; }

    [Required]
    [MaxLength(100)]
    public required string City { get; set; }

    [Required]
    [MaxLength(100)]
    public required string County { get; set; }

    [Required]
    [MaxLength(2)]
    [RegularExpression(@"^[A-Z]{2}$", ErrorMessage = "State must be 2 capital letters")]
    public required string State { get; set; }

    [Required]
    [MaxLength(10)]
    [Display(Name = "ZIP Code")]
    [RegularExpression(@"^\d{5}(-\d{4})?$", ErrorMessage = "Invalid ZIP code format")]
    public required string PostalCode { get; set; }

    [NotMapped]
    public string FullName => $"{FirstName} {(string.IsNullOrEmpty(MiddleInitial) ? "" : MiddleInitial + " ")}{LastName}";

    public virtual ICollection<Role> Roles { get; set; } = new HashSet<Role>();
}
