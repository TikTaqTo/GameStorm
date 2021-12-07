using GameService.Api.Filters;
using GameService.Api.MappingProfiles;
using GameService.Application;
using GameService.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GameService.Api.OnStartup {

  public class Startup {

    public Startup(IConfiguration configuration) {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    private readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

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

      services.AddCors(options => {
        options.AddPolicy(name: MyAllowSpecificOrigins,
                          builder => {
                            builder.WithOrigins("https://localhost:5001/swagger",
                                                    "http://localhost:3000")
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                          });
      });

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

      app.UseCors(MyAllowSpecificOrigins);

      app.UseAuthentication();

      app.UseAuthorization();

      app.UseEndpoints(endpoints => {
        endpoints.MapControllers();
      });
    }
  }
}