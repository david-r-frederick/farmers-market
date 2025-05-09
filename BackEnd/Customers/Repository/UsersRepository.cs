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
    protected readonly IDbContextFactoryWrapper _dbFactory;
    protected readonly IMapper _mapper;
    protected readonly UserManager<User> _userManager;
    protected readonly RoleManager<Role> _roleManager;
    protected readonly SignInManager<User> _signInManager;

    public UsersRepository(
        IDatabaseContext databaseContext,
        IDbContextFactoryWrapper dbFactory,
        IMapper mapper,
        UserManager<User> userManager,
        RoleManager<Role> roleManager,
        SignInManager<User> signInManager)
    {
        _dbFactory = dbFactory;
        _mapper = mapper;
        _userManager = userManager;
        _roleManager = roleManager;
        _signInManager = signInManager;
    }

    public async Task<FullUserModel?> GetByIdAsync(int id)
    {
        using var context = _dbFactory.GetContext();
        var user = await context.Set<User>()
            .Where(x => !x.IsDeleted && x.IsActive && x.Id == id)
            .FirstOrDefaultAsync();
        return _mapper.Map<FullUserModel>(user);
    }

    public async Task<List<ListUserModel>> GetAllAsync(Paging paging)
    {
        using var context = _dbFactory.GetContext();
        var result = await context.Set<User>()
            .Where(x => !x.IsDeleted && x.IsActive)
            .ToListAsync();
        return result.Select(x => _mapper.Map<ListUserModel>(x))
            .ToList();
    }

    public async Task<User> AddAsync(FullUserModel fullUserModel, string password)
    {
        var asEntity = _mapper.Map<User>(fullUserModel);
        var result = await _userManager.CreateAsync(asEntity, password);
        if (!result.Succeeded)
        {
            var description = $"""
                ERROR! Unable to create user with provided information.
                FullUserModel: {fullUserModel.ToString()}.
                {string.Join(", ", result.Errors.Select(e => e.Description))}
            """;
            await Logger.LogErrorAsync(
                description,
                methodName: "UsersRepository.AddAsync",
                null,
                null);
            throw new Exception(description);
        }
        await Logger.LogInfoAsync("A user was created.", "UsersRepository.AddAsync");
        return asEntity;
    }

    public async Task UpdateAsync(FullUserModel fullUserModel)
    {
        using var context = _dbFactory.GetContext();
        var entity = await context.Set<User>()
            .Where(x => x.Id == fullUserModel.Id && !x.IsDeleted)
            .FirstOrDefaultAsync();
        if (entity == null)
        {
            throw new Exception("Unable to find an entity that matches the provided user's Id.");
        }
        context.Set<User>().Update(entity);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        using var context = _dbFactory.GetContext();
        var entity = await context.Set<User>()
            .Where(x => x.Id == id && !x.IsDeleted)
            .FirstOrDefaultAsync();
        if (entity != null)
        {
            entity.IsDeleted = true;
            entity.DeletedOn = DateTime.UtcNow;
            context.Set<User>().Update(entity);
            await context.SaveChangesAsync();
        }
    }

    public async Task<bool> LogInAsync(
        string userName,
        string password)
    {
        using var context = _dbFactory.GetContext();
        var user = await context.Set<User>()
            .Where(x => x.IsActive && x.Email == userName)
            .SingleOrDefaultAsync();
        if (user is null)
        {
            throw new Exception("Username or password not recognized.");
        }
        try
        {
            await _signInManager.SignInAsync(user, false);
            return true;
        }
        catch (Exception ex)
        {
            await Logger.LogErrorAsync(
                $"Signing user in failed. UserName: {userName}. Message: {ex.Message}",
                methodName: "UsersRepository.LogInAsync",
                ex.StackTrace,
                null);
            return false;
        }
    }
}
