namespace Media;

using Core;
using Media.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public class MediaPlugin : IPlugin
{
    public string Name => "Media";

    public string Description => "Contains the entities, controllers, and repositories (workflows) for stored files.";

    public void Initialize(IServiceCollection services, IConfiguration _)
    {
        MediaRepository.Initialize(services);
        services.AddScoped<IMediaRepository, MediaRepository>();
    }

    public void RegisterControllers(IMvcBuilder builder)
    {
    }
}