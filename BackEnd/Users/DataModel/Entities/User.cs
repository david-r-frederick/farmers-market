namespace Users.DataModel.Entities;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.DataModel.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

[Table("Users")]
[Index(nameof(ID))]
[Index(nameof(IsActive))]
[Index(nameof(IsDeleted))]
[Index(nameof(LastName))]
[Index(nameof(FirstName))]
public partial class User : IdentityUser<int>, IBaseEntity
{
    public virtual DateTime CreatedOn { get; set; }

    public virtual string? CreatedBy { get; set; }

    public virtual string? DeletedBy { get; set; }

    public virtual DateTime DeletedOn { get; set; }

    [Key]
    public virtual int ID { get; set; }

    [DefaultValue(true)]
    public virtual bool IsActive { get; set; }

    [DefaultValue(false)]
    public virtual bool IsDeleted { get; set; }

    public virtual string? Key { get; set; }

    public virtual string? UpdatedBy { get; set; }

    public virtual DateTime? UpdatedOn { get; set; }

    [Required(ErrorMessage = "First name is required")]
    [MaxLength(100)]
    [Display(Name = "First Name")]
    public required string FirstName { get; set; }

    [Required(ErrorMessage = "Last name is required")]
    [MaxLength(100)]
    [Display(Name = "Last Name")]
    public required string LastName { get; set; }

    [MaxLength(1)]
    [Display(Name = "MI")]
    [Column("MiddleInitial")]
    public string? MiddleInitial { get; set; }

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
