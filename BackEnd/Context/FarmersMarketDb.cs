namespace Context;

using Core.DataModel.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Reflection;
using Core.DataModel;
using Events.DataModel.Entities;

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
        var assembliesToLoad = new[]
        {
            "Customers",
            "Events",
            "Geography",
            "Media",
            "Products",
        };

        foreach (var assemblyName in assembliesToLoad)
        {
            Assembly.Load(assemblyName);
        }

        var assemblies = AppDomain.CurrentDomain.GetAssemblies()
            .ToList();

        var entityTypes = assemblies
            .SelectMany(a => a.GetTypes())
            .Where(t => t.GetCustomAttribute<SQLTableAttribute>() != null && !t.IsAbstract);

        foreach (var type in entityTypes)
        {
            var attribute = type.GetCustomAttribute<SQLTableAttribute>();
            if (attribute != null)
            {
                modelBuilder.Entity(type).ToTable(attribute.TableName, attribute.Schema);
            }
        }

        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            if (typeof(BaseEntity).IsAssignableFrom(entityType.ClrType))
            {
                var parameter = Expression.Parameter(entityType.ClrType);
                var body = Expression.Not(Expression.Property(parameter, "IsDeleted"));
                var lambda = Expression.Lambda(body, parameter);
                modelBuilder.Entity(entityType.ClrType).HasQueryFilter(lambda);

                modelBuilder.Entity(entityType.ClrType)
                    .Property(nameof(BaseEntity.CreatedOn))
                    .HasDefaultValueSql("GETUTCDATE()");

                modelBuilder.Entity(entityType.ClrType)
                    .Property(nameof(BaseEntity.IsDeleted))
                    .HasDefaultValue(false);

                modelBuilder.Entity(entityType.ClrType)
                    .Property(nameof(BaseEntity.IsActive))
                    .HasDefaultValue(true);
            }
        }

        modelBuilder.Entity<EventVendor>()
            .HasOne(ev => ev.Event)
            .WithMany(e => e.EventVendors)
            .HasForeignKey(ev => ev.EventId);

        modelBuilder.Entity<EventVendor>()
            .HasOne(ev => ev.Vendor)
            .WithMany(v => v.EventVendors)
            .HasForeignKey(ev => ev.VendorId);

        base.OnModelCreating(modelBuilder);
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
