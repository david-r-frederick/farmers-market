namespace Core.Models;

public class BaseModel : IBaseModel
{
    public int Id { get; set; }

    public string? Key { get; set; }
}
