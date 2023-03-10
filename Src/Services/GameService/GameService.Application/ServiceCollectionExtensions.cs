using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using GameService.Application.Behaviors;

namespace GameService.Application {

  public static class ServiceCollectionExtensions {

    public static IServiceCollection AddApplication(this IServiceCollection services,
           Assembly[] automapperAssemblies) {
      services.AddAutoMapper(automapperAssemblies);
      services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
      services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
      services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
      services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidatorBehavior<,>));
      return services;
    }
  }
}