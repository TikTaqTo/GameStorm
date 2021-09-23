using System;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace UserIdentityService.Infrastructure.Persistence {
  public static class ServiceCollectionExtensions {

    /// <summary>
    ///     Inject infrastructure project
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    /// <returns></returns>
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        IConfiguration configuration) {
      services.AddDbContext<UserIdentityServiceContext>(options => {
        options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
            sqlOptions => {
              sqlOptions.MigrationsAssembly(typeof(ServiceCollectionExtensions).GetTypeInfo()
                          .Assembly.GetName().Name);
              sqlOptions.EnableRetryOnFailure(3,
                          TimeSpan.FromSeconds(10), null);
            });
      });

      services.AddHttpContextAccessor();
      return services;
    }
  }
}
