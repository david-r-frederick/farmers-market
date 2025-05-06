namespace Customers;

using Core;
using Microsoft.Extensions.DependencyInjection;
using Customers.Repository;
using Customers.Controllers;
using Core.DataModel.Seeding;
using Customers.DataModel.Seeding;

public class CustomersPlugin : IPlugin
{
    public string Name => "Customers";

    public string Description => "Contains entities, controllers, and repositories (workflows) for " +
        "customers and users. A customer has nothing special about it at this time - it's just a way " +
        "for users to be grouped together (i.e. multiple vendors might eventually be connected somehow).";

    public void Initialize(IServiceCollection services)
    {
        services.AddScoped<ISeeder, RoleSeeder>();
        services.AddScoped<ICustomersRepository, CustomersRepository>();
        services.AddScoped<IUsersRepository, UsersRepository>();
    }

    public void RegisterControllers(IMvcBuilder builder)
    {
        builder.AddApplicationPart(typeof(UsersController).Assembly)
            .AddControllersAsServices();
        builder.AddApplicationPart(typeof(CustomersController).Assembly)
            .AddControllersAsServices();
    }
}