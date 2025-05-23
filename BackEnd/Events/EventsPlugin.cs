﻿namespace Events;

using Core;
using Events.Repository;
using Events.Controllers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

public class EventsPlugin : IPlugin
{
    public string Name => "Events";

    public string Description => "Contains entities, repositories, and controllers for events. Events are used in the sense " +
        "of a real life event - a birthday party, a wedding, etc. They are not tied to 'programming' events. Every event " +
        "has vendors and booths";

    public void Initialize(IServiceCollection services, IConfiguration _)
    {
        EventsRepository.Initialize(services);
        services.AddScoped<IEventsRepository, EventsRepository>();
        VendorsRepository.Initialize(services);
        services.AddScoped<IVendorsRepository, VendorsRepository>();
    }

    public void RegisterControllers(IMvcBuilder builder)
    {
        builder.AddApplicationPart(typeof(EventsController).Assembly)
            .AddControllersAsServices();
    }
}