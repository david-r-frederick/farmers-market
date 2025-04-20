namespace Context;

using Core;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

public class DbContextFactoryWrapper : IDbContextFactoryWrapper
{
    private readonly IDbContextFactory<FarmersMarketDb> _factory;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public DbContextFactoryWrapper(
        IDbContextFactory<FarmersMarketDb> factory,
        IHttpContextAccessor httpContextAccessor)
    {
        _factory = factory;
        _httpContextAccessor = httpContextAccessor;
    }

    public IDatabaseContext GetContext()
    {
        var context = _factory.CreateDbContext();
        typeof(FarmersMarketDb)
            .GetField("_httpContextAccessor", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            ?.SetValue(context, _httpContextAccessor);
        return context;
    }
}