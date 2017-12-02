using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CVIMS.Api
{
    public partial class Startup
    {
        public static void ConfigureCorsServices(IConfiguration Configuration, IServiceCollection services)
        {
            //CORS
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", config =>
                {
                    config.AllowAnyHeader();
                    config.AllowAnyMethod();
                    //config.WithOrigins(Configuration.GetSection("CorsOrigin").Value);
                    config.AllowAnyOrigin();
                    config.AllowCredentials();
                });
            });
        }

        public static void ConfigureCors(IApplicationBuilder app)
        {
            //app.UseCors(ALLOW_SPECIFIC_ORIGIN);
            app.UseCors("AllowAll");
        }
    }
}