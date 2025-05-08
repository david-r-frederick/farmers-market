namespace Core;

using System.Threading.Tasks;
using AutoMapper;
using Core.DataModel.Entities;
using Core.DataModel.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

public abstract class Repository<TEntity, TFullModel, TListModel> : IRepository<TFullModel, TListModel>
    where TEntity : BaseEntity
    where TFullModel : BaseModel
    where TListModel : BaseModel

{
    protected readonly IDbContextFactoryWrapper _dbFactory;
    protected readonly IMapper _mapper;
    protected readonly IHttpContextAccessor _httpContextAccessor;

    protected Repository(
        IDbContextFactoryWrapper dbContextFactoryWrapper,
        IMapper mapper,
        IHttpContextAccessor httpContextAccessor)
    {
        _dbFactory = dbContextFactoryWrapper;
        _mapper = mapper;
        _httpContextAccessor = httpContextAccessor;
    }

    public virtual async Task<TFullModel?> GetByIdAsync(int id)
    {
        using var context = _dbFactory.GetContext();
        var result = await context.Set<TEntity>()
            .Where(x => !x.IsDeleted && x.IsActive && x.Id == id)
            .FirstOrDefaultAsync();
        return _mapper.Map<TFullModel>(result);
    }

    public virtual async Task<TFullModel?> GetByKeyAsync(string key)
    {
        using var context = _dbFactory.GetContext();
        var result = await context.Set<TEntity>()
            .Where(x => !x.IsDeleted && x.IsActive && x.Key == key)
            .FirstOrDefaultAsync();
        return _mapper.Map<TFullModel>(result);
    }

    public virtual async Task<PagedResult<TListModel>> GetAllAsync(Paging paging)
    {
        var pageNumber = paging.PageNumber ?? 1;
        var pageSize = paging.PageSize ?? 8;

        using var context = _dbFactory.GetContext();
        var query = context.Set<TEntity>()
            .Where(x => !x.IsDeleted && x.IsActive);
        var totalCount = await query.CountAsync();
        var items = await query
            .OrderBy(x => x.Id)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        var mappedItems = _mapper.Map<List<TListModel>>(items);
        return new PagedResult<TListModel>(mappedItems, pageNumber, pageSize, totalCount);
    }

    public virtual async Task<int> AddAsync(TFullModel model)
    {
        using var context = _dbFactory.GetContext();
        var entity = _mapper.Map<TEntity>(model);
        await context.Set<TEntity>().AddAsync(entity);
        await context.SaveChangesAsync();
        return entity.Id;
    }

    public virtual async Task UpdateAsync(TFullModel model)
    {
        using var context = _dbFactory.GetContext();
        var entity = await context.Set<TEntity>()
            .Where(x => x.Id == model.Id && !x.IsDeleted)
            .FirstOrDefaultAsync();
        if (entity == null)
        {
            throw new Exception("Unable to find an entity that matches the provided model's Id.");
        }
        _mapper.Map(model, entity);
        context.Set<TEntity>().Update(entity);
        await context.SaveChangesAsync();
    }

    public virtual async Task DeleteAsync(int id)
    {
        using var context = _dbFactory.GetContext();
        var entity = await context.Set<TEntity>()
            .Where(x => x.Id == id && !x.IsDeleted)
            .FirstOrDefaultAsync();
        if (entity != null)
        {
            entity.IsDeleted = true;
            entity.DeletedOn = DateTime.UtcNow;
            context.Set<TEntity>().Update(entity);
            await context.SaveChangesAsync();
        }
    }
}