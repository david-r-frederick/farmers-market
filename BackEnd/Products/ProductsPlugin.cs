namespace Products;

using Microsoft.Extensions.DependencyInjection;
using Core;
using Products.Controllers;
using Products.Repository;
using Products.Seeders;
using Core.Seeding;

public class ProductsPlugin : IPlugin
{
    public string Name => "Products";

    public string Description => "Contains entities, controllers, and repositories (workflows) for products. " +
        "Products are not purchaseable on the site - they are only viewable when viewing a vendor " +
        "or to an admin. They do not have things an ecommerce site would have like inventory and pricing.";

    public void Initialize(IServiceCollection services)
    {
        services.AddScoped<IProductsRepository, ProductsRepository>();
        services.AddScoped<ISeeder, ProductTypeSeeder>();
    }

    public void RegisterControllers(IMvcBuilder builder)
    {
        builder.AddApplicationPart(typeof(ProductsController).Assembly)
            .AddControllersAsServices();
    }
}