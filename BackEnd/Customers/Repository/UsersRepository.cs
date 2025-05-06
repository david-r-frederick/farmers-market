namespace Customers.Repository;

using AutoMapper;
using Core;
using Core.DataModel.Models;
using Customers.DataModel.Entities;
using Customers.DataModel.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

public class UsersRepository : IUsersRepository
{
    protected readonly IDatabaseContext _databaseContext;
    protected readonly IMapper _mapper;
    protected readonly UserManager<User> _userManager;
    protected readonly RoleManager<Role> _roleManager;

    public UsersRepository(
        IDatabaseContext databaseContext,
        IMapper mapper,
        UserManager<User> userManager,
        RoleManager<Role> roleManager)
    {
        _databaseContext = databaseContext;
        _mapper = mapper;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task<FullUserModel?> GetByIdAsync(int id)
    {
        var user = await _databaseContext.Set<User>()
            .Where(x => !x.IsDeleted && x.IsActive && x.Id == id)
            .FirstOrDefaultAsync();
        return _mapper.Map<FullUserModel>(user);
    }

    public async Task<List<ListUserModel>> GetAllAsync(Paging paging)
    {
        var result = await _databaseContext.Set<User>()
            .Where(x => !x.IsDeleted && x.IsActive)
            .ToListAsync();
        return result.Select(x => _mapper.Map<ListUserModel>(x))
            .ToList();
    }

    public async Task<int> AddAsync(FullUserModel fullUserModel, string password)
    {
        var asEntity = _mapper.Map<User>(fullUserModel);
        var result = await _userManager.CreateAsync(asEntity, password);
        if (!result.Succeeded)
        {
            throw new Exception(
                $"""
                    ERROR! Unable to create user with provided information.
                    {string.Join(", ", result.Errors.Select(e => e.Description))}
                """
            );
        }
        await _userManager.AddToRoleAsync(asEntity, "Vendor");
        await Logger.LogInfoAsync("A user was created.");
        return asEntity.Id;
    }

    public async Task UpdateAsync(FullUserModel fullUserModel)
    {
        var entity = await _databaseContext.Set<User>()
            .Where(x => x.Id == fullUserModel.Id && !x.IsDeleted)
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
