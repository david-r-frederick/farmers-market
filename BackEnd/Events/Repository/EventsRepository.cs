namespace Events.Repository;

using Core;
using Events.DataModel.Entities;

public class EventsRepository : Repository<Event>, IEventsRepository
{
    public EventsRepository(IDatabaseContext databaseContext)
        : base(databaseContext)
    {
    }
}
