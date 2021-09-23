using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using UserIdentityService.Application.Behaviors;

namespace UserIdentityService.Application {
  public static class ServiceCollectionExtensions {

    public static IServiceCollection AddApplication(this IServiceCollection services,
           Assembly[] automapperAssemblies) {
      services.AddAutoMapper(automapperAssemblies);
      services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
      services.AddMediatR(Assembly.GetExecutingAssembly());
      services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
      services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidatorBehavior<,>));
      return services;
    }
  }
}
