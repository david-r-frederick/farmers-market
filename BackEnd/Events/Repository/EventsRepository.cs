namespace Events.Repository;

using Core;
using Events.DataModel.Models;

public class EventsRepository : Repository<EventModel>, IEventsRepository
{
    public EventsRepository(IDbContextFactoryWrapper dbFactory)
        : base(dbFactory)
    {
    }
}
