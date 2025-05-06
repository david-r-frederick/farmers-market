namespace Events.DataModel.Models;

using Core.DataModel.Models;

public class FullEventModel : BaseModel
{
    public string StartDate { get; set; } = null!;

    public string EndDate { get; set; } = null!;
}
