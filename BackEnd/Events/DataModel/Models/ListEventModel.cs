namespace Events.DataModel.Models;

using Core.Models;

public class ListEventModel : BaseModel
{
    public string StartDate { get; set; } = null!;

    public string EndDate { get; set; } = null!;
}
