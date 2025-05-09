namespace Geography;

using Core;
using Microsoft.Extensions.DependencyInjection;
using Geography.Repository;
using Geography.Controllers;

public class GeographyPlugin : IPlugin
{
    public string Name => "Geography";

    public string Description => "Contains the entities, controllers, and repositories for geography " +
        "(only addresses at this time). Could be modified to include translations and countries down the road" +
        ", but this is beyond the current scope. 04/19/2025";

    public void Initialize(IServiceCollection services)
    {
        AddressesRepository.Initialize(services);
        services.AddScoped<IAddressesRepository, AddressesRepository>();
    }

    public void RegisterControllers(IMvcBuilder builder)
    {
        builder.AddApplicationPart(typeof(AddressesController).Assembly)
            .AddControllersAsServices();
    }
}