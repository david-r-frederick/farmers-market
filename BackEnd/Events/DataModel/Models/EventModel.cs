namespace Events.DataModel.Models;

using Core.Models;

public class EventModel : BaseModel
{
    public string StartDate { get; set; } = null!;

    public string EndDate { get; set; } = null!;
}
