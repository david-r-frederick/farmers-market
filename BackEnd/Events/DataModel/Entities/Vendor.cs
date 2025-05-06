namespace Events.DataModel.Entities;

using Core;
using Core.DataModel.Entities;
using Customers.DataModel.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

[SQLTable("Events", "Vendor")]
public partial class Vendor : BaseEntity
{
    public int UserId { get; set; }

    public virtual User? User { get; set; }

    public bool SignedDisclosure { get; set; }

    [JsonIgnore]
    [ForeignKey("Business")]
    public int? BusinessId { get; set; }

    public virtual Business? Business { get; set; }

    public ICollection<Booth> Booths { get; set; } = new HashSet<Booth>();

    public virtual ICollection<EventVendor> EventVendors { get; set; } = new HashSet<EventVendor>();
}
