namespace Events.Repository;

using AutoMapper;
using Core;
using Events.DataModel.Entities;
using Events.DataModel.Models;
using Microsoft.AspNetCore.Http;

public class EventsRepository : Repository<Event, FullEventModel, ListEventModel>, IEventsRepository
{
    public EventsRepository(
        IDbContextFactoryWrapper dbFactory,
        IMapper mapper,
        IHttpContextAccessor httpContextAccessor) : base(dbFactory, mapper, httpContextAccessor)
    {
    }
}
