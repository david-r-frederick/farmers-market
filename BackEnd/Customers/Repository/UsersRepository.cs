namespace Customers.Repository;

using AutoMapper;
using Core;
using Core.Models;
using Customers.DataModel.Entities;
using Microsoft.EntityFrameworkCore;

public class UsersRepository : IUsersRepository
{
    protected readonly IDatabaseContext _databaseContext;
    protected readonly IMapper _mapper;

    public UsersRepository(
        IDatabaseContext databaseContext,
        IMapper mapper)
    {
        _databaseContext = databaseContext;
        _mapper = mapper;
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        return await _databaseContext.Set<User>()
            .Where(x => !x.IsDeleted && x.IsActive && x.Id == id)
            .FirstOrDefaultAsync();
    }

    public async Task<List<User>> GetAllAsync(Paging paging)
    {
        var result = await _databaseContext.Set<User>()
            .Where(x => !x.IsDeleted && x.IsActive)
            .ToListAsync();
        return result.Select(x => _mapper.Map<User>(x))
            .ToList();
    }

    public async Task<int> AddAsync(User entity)
    {
        await _databaseContext.Set<User>().AddAsync(entity);
        await _databaseContext.SaveChangesAsync();
        return entity.Id;
    }

    public async Task UpdateAsync(User user)
    {
        var entity = await _databaseContext.Set<User>()
            .Where(x => x.Id == user.Id && !x.IsDeleted)
            .FirstOrDefaultAsync();
        if (entity == null)
        {
            throw new Exception("Unable to find an entity that matches the provided user's Id.");
        }
        _databaseContext.Set<User>().Update(entity);
        await _databaseContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _databaseContext.Set<User>()
            .Where(x => x.Id == id && !x.IsDeleted)
            .FirstOrDefaultAsync();
        if (entity != null)
        {
            entity.IsDeleted = true;
            entity.DeletedOn = DateTime.UtcNow;
            _databaseContext.Set<User>().Update(entity);
            await _databaseContext.SaveChangesAsync();
        }
    }
}
