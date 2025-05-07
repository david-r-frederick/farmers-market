using Products.DataModel.Models;

namespace Events.DataModel.Models;

public class RegisterForEventForm
{
    public int EventId { get; set; }

    public List<FullProductModel> ProductsSelling { get; set; } = null!;

    public int BoothId { get; set; }

    public int? PreferredBoothId { get; set; }

    public bool DoesAgreeToTerms { get; set; }

    public bool AgreesToPayUponArrival { get; set; }

    public string SpotSizeOrLocation { get; set; } = null!;
}
