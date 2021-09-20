using GameService.Application.Abstractions.Dictionaries;
using GameService.Application.Abstractions.Media;
using GameService.Application.Abstractions.VideoGame;
using GameService.Infrastructure.Persistence;
using GameService.Infrastructure.Repositories.Dictionaries;
using GameService.Infrastructure.Repositories.Media;
using GameService.Infrastructure.Repositories.VideoGame;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;

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

      services.AddScoped<IGameService, GameRepository>();
      services.AddScoped<IImageService, ImageRepository>();
      services.AddScoped<IDeveloperService, DeveloperRepository>();
      services.AddScoped<IGenreService, GenreRepository>();
      services.AddScoped<IPlatformService, PlatformRepository>();
      services.AddScoped<IPublisherService, PublisherRepository>();
      services.AddScoped<ITagService, TagRepository>();

      return services;
    }
  }
}