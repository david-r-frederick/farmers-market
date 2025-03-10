namespace Core;

using Core.DataModel.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

public class FarmersMarketDb : IdentityDbContext<User, IdentityRole<int>, int>
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public FarmersMarketDb(
        DbContextOptions<FarmersMarketDb> options,
        IHttpContextAccessor httpContextAccessor) : base(options)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            if (typeof(BaseEntity).IsAssignableFrom(entityType.ClrType))
            {
                var parameter = Expression.Parameter(entityType.ClrType);
                var body = Expression.Not(Expression.Property(parameter, "IsDeleted"));
                var lambda = Expression.Lambda(body, parameter);
                modelBuilder.Entity(entityType.ClrType).HasQueryFilter(lambda);

                modelBuilder.Entity(entityType.ClrType)
                    .Property("CreatedOn")
                    .HasDefaultValueSql("GETUTCDATE()");

                modelBuilder.Entity(entityType.ClrType)
                    .Property("IsDeleted")
                    .HasDefaultValue(false);

                modelBuilder.Entity(entityType.ClrType)
                    .Property("IsActive")
                    .HasDefaultValue(true);
            }
        }
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker
            .Entries()
            .Where(x => x.Entity is BaseEntity
                && (x.State == EntityState.Added
                    || x.State == EntityState.Modified
                    || x.State == EntityState.Deleted));

        foreach (var entityEntry in entries)
        {
            if (entityEntry.State == EntityState.Added)
            {
                AssignCreationValues((BaseEntity)entityEntry.Entity);
            }
            if (entityEntry.State == EntityState.Deleted)
            {
                AssignDeletionValues((BaseEntity)entityEntry.Entity);
            }

            AssignUpdateValues((BaseEntity)entityEntry.Entity);
        }
        return base.SaveChangesAsync(cancellationToken);
    }

    private void AssignCreationValues(BaseEntity entity)
    {
        var currentUser = _httpContextAccessor?.HttpContext?.User?.Identity?.Name ?? "System";
        entity.CreatedOn = DateTime.UtcNow;
        entity.CreatedBy = currentUser;
    }

    private void AssignUpdateValues(BaseEntity entity)
    {
        entity.UpdatedOn = DateTime.UtcNow;
    }

    private void AssignDeletionValues(BaseEntity entity)
    {
        entity.IsDeleted = true;
        entity.DeletedOn = DateTime.UtcNow;
    }

    public IQueryable<TEntity> GetUnfiltered<TEntity>() where TEntity : BaseEntity
    {
        return Set<TEntity>().IgnoreQueryFilters();
    }

    public bool CanConnect()
    {
        try
        {
            return Database.CanConnect();
        }
        catch
        {
            return false;
        }
    }
}
