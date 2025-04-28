namespace Categories;

using Microsoft.Extensions.DependencyInjection;
using Core;
using Categories.Controllers;
using Categories.Repository;

public class CategoriesPlugin : IPlugin
{
    public string Name => "Categories";

    public string Description => "Contains entities, controllers, and repositories (workflows) for categories.";

    public void Initialize(IServiceCollection services)
    {
        services.AddScoped<ICategoriesRepository, CategoriesRepository>();
    }

    public void RegisterControllers(IMvcBuilder builder)
    {
        builder.AddApplicationPart(typeof(CategoriesController).Assembly)
            .AddControllersAsServices();
    }
}