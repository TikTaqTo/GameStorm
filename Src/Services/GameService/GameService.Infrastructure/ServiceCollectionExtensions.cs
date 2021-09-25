using GameService.Application.Abstractions.Dictionaries;
using GameService.Application.Abstractions.Media;
using GameService.Application.Abstractions.VideoGame;
using GameService.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using GameService.Infrastructure.Services.Dictionaries;
using GameService.Infrastructure.Services.Media;
using GameService.Infrastructure.Services.VideoGame;


namespace GameService.Infrastructure {

  public static class ServiceCollectionExtensions {

    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration) {
      services.AddDbContext<GameServiceContext>(options => {
        options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
            sqlOptions => {
              sqlOptions.MigrationsAssembly(typeof(ServiceCollectionExtensions).GetTypeInfo().Assembly
                          .GetName().Name);
              sqlOptions.EnableRetryOnFailure(
                          Convert.ToInt32(configuration.GetSection("InfrastructureSettings:MaxRetryCount").Value),
                          TimeSpan.FromSeconds(
                              Convert.ToInt32(configuration.GetSection("InfrastructureSettings:MaxDelayCount")
                                  .Value)),
                          null);
            });
      });

      services.AddHttpContextAccessor();

      services.AddScoped<IGameService, GamesService>();
      services.AddScoped<IImageService, ImageService>();
      services.AddScoped<IDeveloperService, DeveloperService>();
      services.AddScoped<IGenreService, GenreService>();
      services.AddScoped<IPlatformService, PlatformService>();
      services.AddScoped<IPublisherService, PublisherService>();
      services.AddScoped<ITagService, TagService>();

      return services;
    }
  }
}