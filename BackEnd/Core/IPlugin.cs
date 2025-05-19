namespace Core;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public interface IPlugin
{
    string Name { get; }

    string Description { get; }

    void Initialize(IServiceCollection services, IConfiguration configuration);

    void RegisterControllers(IMvcBuilder builder);
}