namespace Context;

using Customers.DataModel.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Reflection;
using Events.DataModel.Entities;
using Core;
using Core.Entities;
using Microsoft.AspNetCore.DataProtection.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

public class FarmersMarketDb
    : IdentityDbContext<
        User,
        Role,
        int,
        UserClaim,
        UserRole,
        UserLogin,
        RoleClaim,
        UserToken>,
        IDatabaseContext
{
    public DbSet<DataProtectionKey> DataProtectionKeys => Set<DataProtectionKey>();

    private readonly IHttpContextAccessor? _httpContextAccessor;

    public FarmersMarketDb(
        DbContextOptions<FarmersMarketDb> options,
        IHttpContextAccessor? httpContextAccessor) : base(options)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<DataProtectionKey>().ToTable(nameof(DataProtectionKey), "Core");
        var assembliesToLoad = new[]
        {
            "Categories",
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

    public async Task SeedEntitiesAsync<T>(IEnumerable<T> entities) where T : BaseEntity
    {
        foreach (var entity in entities)
        {
            var existingEntity = await Set<T>()
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Key == entity.Key);
            if (existingEntity == null)
            {
                await Set<T>().AddAsync(entity);
            }
        }
        await SaveChangesAsync();
    }

    public T CreateBaseEntity<T>(string key) where T : BaseEntity
    {
        var entity = Activator.CreateInstance<T>();
        entity.Key = key;
        entity.CreatedOn = DateTime.UtcNow;
        entity.CreatedBy = "System";
        entity.IsActive = true;
        entity.IsDeleted = false;
        return entity;
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
