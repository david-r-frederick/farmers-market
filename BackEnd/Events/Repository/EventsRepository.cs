namespace Events.Repository;

using Core;
using Events.DataModel.Entities;
using Events.DataModel.Models;

public class EventsRepository : Repository<Event, FullEventModel, ListEventModel>, IEventsRepository
{
}
