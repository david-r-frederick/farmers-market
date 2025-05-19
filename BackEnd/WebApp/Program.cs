using Context;
using Core;
using Core.DataModel.Seeding;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContextFactory<FarmersMarketDb>(
    options =>
    {
        options.UseSqlServer(
            builder.Configuration.GetConnectionString("DefaultConnection"),
            b => b.MigrationsAssembly("WebApp"));
    },
    ServiceLifetime.Transient);
builder.Services.AddScoped<IDatabaseContext>(provider => provider.GetService<FarmersMarketDb>()!);
builder.Services.AddScoped<IDbContextFactoryWrapper, DbContextFactoryWrapper>();
builder.Services.AddScoped(provider =>
{
    var factory = provider.GetRequiredService<IDbContextFactory<FarmersMarketDb>>();
    var httpContextAccessor = provider.GetRequiredService<IHttpContextAccessor>();
    return new DbContextFactoryWrapper(factory, httpContextAccessor);
});

builder.Services.AddIdentity<
    Customers.DataModel.Entities.User,
    Customers.DataModel.Entities.Role>(options =>
    {
        options.SignIn.RequireConfirmedAccount = false;
    })
    .AddEntityFrameworkStores<FarmersMarketDb>()
    .AddDefaultTokenProviders();

var assemblies = AppDomain.CurrentDomain.GetAssemblies()
    .Where(a => !a.IsDynamic)
    .ToList();
assemblies.AddRange(new[]
{
    typeof(CorePlugin).Assembly,
    typeof(Products.ProductsPlugin).Assembly,
    typeof(Customers.CustomersPlugin).Assembly,
    typeof(Events.EventsPlugin).Assembly,
    typeof(Geography.GeographyPlugin).Assembly,
    typeof(Media.MediaPlugin).Assembly,
    typeof(Categories.CategoriesPlugin).Assembly,
    typeof(Core.Mapping.BaseMappingProfile).Assembly,
}.Distinct());
builder.Services.AddAutoMapper(assemblies);
var plugins = new List<IPlugin>();
var initializedPluginTypes = new HashSet<Type>();
foreach (var assembly in assemblies)
{
    var pluginTypes = assembly.GetTypes()
        .Where(t => typeof(IPlugin).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract);
    foreach (var type in pluginTypes)
    {
        if (initializedPluginTypes.Contains(type))
        {
            continue;
        }
        try
        {
            var plugin = (IPlugin)Activator.CreateInstance(type)!;
            plugins.Add(plugin);
            plugin.Initialize(builder.Services, builder.Configuration);
            plugin.RegisterControllers(builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
                options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
            }));
            initializedPluginTypes.Add(type);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to initialize plugin {type.FullName}: {ex.Message}");
        }
    }
}

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
    c.CustomOperationIds(apiDesc =>
    {
        var controller = apiDesc.ActionDescriptor.RouteValues["controller"]?.ToLower();
        var action = apiDesc.ActionDescriptor.RouteValues["action"];
        return $"{controller}_{action}"; // e.g., starting_testTheConnection
    });
});
builder.Services.AddHttpContextAccessor();
var allowedOrigins = builder.Configuration
    .GetSection("AllowedOrigins")
    .Get<string[]>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy =>
        {
            policy.WithOrigins(allowedOrigins ?? ["http://localhost:5173"])
                  .AllowAnyHeader()
                  .AllowAnyMethod()
                  .AllowCredentials();
        });
});

var app = builder.Build();
Logger.Initialize(app.Services);

using (var scope = app.Services.CreateScope())
{
    await DatabaseInitializer.InitializeAsync(scope.ServiceProvider);
    var dbContext = scope.ServiceProvider.GetRequiredService<FarmersMarketDb>();
    var seeders = scope.ServiceProvider.GetServices<ISeeder>();
    foreach (var seeder in seeders)
    {
        try
        {
            await seeder.SeedAsync(dbContext);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to seed data using {seeder.GetType().Name}: {ex.Message}");
        }
    }
}

app.UsePathBase("/api");
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/api/swagger/v1/swagger.json", "My API v1"));
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseCors("AllowFrontend");
app.MapControllers();
app.Run();
