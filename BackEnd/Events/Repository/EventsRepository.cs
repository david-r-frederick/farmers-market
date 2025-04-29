namespace Events.Repository;

using AutoMapper;
using Core;
using Events.DataModel.Entities;
using Events.DataModel.Models;

public class EventsRepository : Repository<Event, FullEventModel, ListEventModel>, IEventsRepository
{
    public EventsRepository(
        IDbContextFactoryWrapper dbFactory,
        IMapper mapper) : base(dbFactory, mapper)
    {
    }
}
