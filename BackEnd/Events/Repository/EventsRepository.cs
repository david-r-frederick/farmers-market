namespace Events.Repository;

using Events.DataModel.Entities;
using Core;

public class EventsRepository : IEventsRepository
{
    private readonly IDatabaseContext databaseContext;

    public EventsRepository(IDatabaseContext unitOfWork)
    {
        databaseContext = unitOfWork;
    }

    public async Task<Event?> GetByIdAsync(int id)
    {
        return await databaseContext.Set<Event>().FindAsync(id);
    }

    public async Task AddAsync(Event product)
    {
        await databaseContext.Set<Event>().AddAsync(product);
        await databaseContext.SaveChangesAsync(new());
    }
}
