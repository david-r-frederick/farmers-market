namespace Events.Repository;

using Events.DataModel.Entities;

public interface IEventsRepository
{
    Task<Event?> GetByIdAsync(int id);

    Task AddAsync(Event ev);
}
