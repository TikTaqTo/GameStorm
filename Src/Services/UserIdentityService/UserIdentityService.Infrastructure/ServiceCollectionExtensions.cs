using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UserIdentityService.Application.Abstractions;
using UserIdentityService.Domain.EntityModels.User;
using UserIdentityService.Infrastructure.Persistence;
using UserIdentityService.Infrastructure.Services;

namespace UserIdentityService.Infrastructure {
  public static class ServiceCollectionExtensions {
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration) {
      services.AddDbContext<UserIdentityServiceContext>(options => {
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

      services.AddScoped<IClaimService, ClaimService>();
      services.AddScoped<ISecurityService, SecurityService>();

      return services;
    }

    public static void AddDatabaseAuthorizationConfiguration(this IServiceCollection services,
            IConfiguration configuration) {
      services.AddIdentityCore<ApplicationUser>(options => {
        options.Password.RequireDigit = true;
        options.Password.RequireLowercase = true;
        options.Password.RequiredLength = 8;
        options.Password.RequiredUniqueChars = 1;
        options.Password.RequireNonAlphanumeric = true;
      })
          .AddRoles<IdentityRole<Guid>>()
          .AddEntityFrameworkStores<UserIdentityServiceContext>()
          .AddDefaultTokenProviders();

      services.AddAuthentication(auth => {
        auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
      }).AddJwtBearer(options => {
        options.TokenValidationParameters = new TokenValidationParameters {
          ValidateIssuer = true,
          ValidateAudience = true,
          ValidAudience = configuration["AuthSettings:Audience"],
          ValidIssuer = configuration["AuthSettings:Issuer"],
          RequireExpirationTime = true,
          IssuerSigningKey =
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["AuthSettings:Key"])),
          ValidateIssuerSigningKey = true
        };
      });
    }
  }
}
