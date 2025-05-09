namespace Core;

using Core.DataModel.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

public class Logger
{
    private static IServiceProvider? _serviceProvider;

    public static void Initialize(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public static async Task<int> LogInfoAsync(
        string description,
        string methodName)
    {
        var log = new Log
        {
            TypeId = 1,
            Description = description,
            MethodName = methodName,
        };
        return await LogInnerAsync(log);
    }

    public static async Task<int> LogErrorAsync(
        string description,
        string methodName,
        string? stackTrace,
        string? requestPath)
    {
        var log = new Log
        {
            TypeId = 1,
            Description = description,
            StackTrace = stackTrace,
            RequestPath = requestPath,
            MethodName = methodName,
        };

        return await LogInnerAsync(log);
    }

    private static async Task<int> LogInnerAsync(Log log)
    {
        if (_serviceProvider is null)
        {
            throw new ArgumentNullException("Service provider is null in Logger.");
        }
        using var scope = _serviceProvider.CreateScope();
        using var context = scope.ServiceProvider.GetRequiredService<IDatabaseContext>();
        var httpContextAccessor = scope.ServiceProvider.GetRequiredService<IHttpContextAccessor>();
        var userID = httpContextAccessor!.HttpContext?.User?.FindFirst("Id")?.Value;
        log.UserID = userID != null ? int.Parse(userID) : null;
        if (log.RequestPath is null)
        {
            log.RequestPath = httpContextAccessor!.HttpContext?.Request.Path.ToString();
        }
        log.Key = Guid.NewGuid().ToString();
        log.CreatedOn = DateTime.UtcNow;
        await context.Set<Log>().AddAsync(log);
        await context.SaveChangesAsync();
        return log.Id;
    }
}
