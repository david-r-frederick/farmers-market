namespace Customers.DataModel.Models;

public class LogInRequest
{
    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;
}
