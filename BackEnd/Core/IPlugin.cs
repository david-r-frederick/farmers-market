namespace Core;

using Microsoft.Extensions.DependencyInjection;

public interface IPlugin
{
    string Name { get; }

    string Description { get; }

    void Initialize(IServiceCollection services);

    void RegisterControllers(IMvcBuilder builder);
}