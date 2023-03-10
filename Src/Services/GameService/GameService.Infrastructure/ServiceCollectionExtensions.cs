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
using System.Text.Json.Serialization;

namespace GameService.Infrastructure {

  public static class ServiceCollectionExtensions {

    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration) {
      

      services.AddDbContext<GameServiceContext>(options => {
        options.UseInMemoryDatabase(configuration.GetConnectionString("DefaultConnection"));
      });

      services.AddHttpContextAccessor();

      
      services.AddControllers().AddJsonOptions(x =>
      x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);

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