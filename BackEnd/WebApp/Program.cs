using Context;
using Core;
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

var assemblies = AppDomain.CurrentDomain.GetAssemblies()
    .Where(a => !a.IsDynamic)
    .ToList();
assemblies.AddRange(new[]
{
    typeof(Products.ProductsPlugin).Assembly,
    typeof(Customers.CustomersPlugin).Assembly,
    typeof(Events.EventsPlugin).Assembly,
    typeof(Geography.GeographyPlugin).Assembly,
    typeof(Media.MediaPlugin).Assembly,
    typeof(Categories.CategoriesPlugin).Assembly,
    typeof(Core.Mapping.BaseMappingProfile).Assembly,
}.Distinct());
var plugins = new List<IPlugin>();
foreach (var assembly in assemblies)
{
    var pluginTypes = assembly.GetTypes()
        .Where(t => typeof(IPlugin).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract);
    foreach (var type in pluginTypes)
    {
        try
        {
            var plugin = (IPlugin)Activator.CreateInstance(type)!;
            plugins.Add(plugin);
            plugin.Initialize(builder.Services);
            plugin.RegisterControllers(builder.Services.AddControllers());
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
builder.Services.AddAutoMapper(assemblies);
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

using (var scope = app.Services.CreateScope())
{
    await DatabaseInitializer.InitializeAsync(scope.ServiceProvider);
}

// Configure the HTTP request pipeline.
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
