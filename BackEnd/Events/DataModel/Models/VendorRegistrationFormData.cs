namespace Events.DataModel.Models;

public class VendorRegistrationFormData
{
    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Street1 { get; set; } = null!;

    public string Street2 { get; set; } = null!;

    public string City { get; set; } = null!;

    public string County { get; set; } = null!;

    public string State { get; set; } = null!;

    public string ZipCode { get; set; } = null!;

    public string BusinessName { get; set; } = null!;

    public DateTime? BusinessStartDate { get; set; }
}
