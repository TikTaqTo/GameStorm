using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using GameService.Api.Filters;
using GameService.Api.MappingProfiles;
using GameService.Application;
using GameService.Infrastructure;

namespace GameService.Api.OnStartup {
  public class Startup {

      public Startup(IConfiguration configuration) {
        Configuration = configuration;
      }

      public IConfiguration Configuration { get; }

      // This method gets called by the runtime. Use this method to add services to the container.
      public void ConfigureServices(IServiceCollection services) {
        services.AddControllers(x => x.Filters.Add<HttpGlobalExceptionFilter>());

        services.AddApplication(
          new[] {
          typeof(DictionariesProfile).Assembly,
          typeof(GamesProfile).Assembly,
          typeof(MediasProfile).Assembly
          }
          );

        services.AddInfrastructure(Configuration);

        services.AddSwagger();
      }

      // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
      public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
        if (env.IsDevelopment()) {
          app.UseDeveloperExceptionPage();
          app.UseOpenApi();
          app.UseSwaggerUi3();
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthentication();

        app.UseAuthorization();

        app.UseEndpoints(endpoints => {
          endpoints.MapControllers();
        });
      }
    }
  }