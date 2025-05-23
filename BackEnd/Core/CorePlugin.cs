﻿using Core.Controllers;
using Core.DataModel.Seeding;
using Core.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Core;

public class CorePlugin : IPlugin
{
    public string Name => "Core";

    public string Description => "Contains CORE entities, repositories, and workflows.";

    public void Initialize(IServiceCollection services, IConfiguration _)
    {
        services.AddScoped<ISeeder, LogTypeSeeder>();
        SettingsRepository.Initialize(services);
        services.AddScoped<ISettingsRepository, SettingsRepository>();
        services.AddScoped<ISeeder, SettingSeeder>();
    }

    public void RegisterControllers(IMvcBuilder builder)
    {
        builder.AddApplicationPart(typeof(SettingsController).Assembly)
            .AddControllersAsServices();
    }
}
