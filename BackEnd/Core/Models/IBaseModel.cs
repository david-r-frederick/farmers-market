namespace Core.Models;

public interface IBaseModel
{
    int Id { get; set; }

    string? Key { get; set; }
}
