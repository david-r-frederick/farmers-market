using Context;
using Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Products.Controllers;
using Products.Repository;

var builder = WebApplication.CreateBuilder(args);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<FarmersMarketDb>(
    options =>
    {
        options.UseSqlServer(
            builder.Configuration.GetConnectionString("DefaultConnection"),
            b => b.MigrationsAssembly("WebApp"));
    },
    ServiceLifetime.Transient);
builder.Services.AddScoped<IDatabaseContext>(provider => provider.GetService<FarmersMarketDb>()!);
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddControllers()
    .AddApplicationPart(typeof(ProductController).Assembly)
    .AddControllersAsServices();
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
