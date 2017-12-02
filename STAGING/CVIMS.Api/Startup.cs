using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using CVIMS.Api.Infrastructure.Auth;

namespace CVIMS.Api
{
    public partial class Startup
    {
        private const string ALLOW_SPECIFIC_ORIGIN = "AllowSpecificOrigin";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureCorsServices(Configuration, services);

            ConfigureEFServices(Configuration, services);

            services.AddAntiforgery(options => options.HeaderName = "X-XSRF-TOKEN");

            services.AddMvc();

            services.AddAutoMapper();

            ConfigureAuthServices(Configuration, services);

            ConfigureSwaggerServices(services);

            ConfigureDIServices(services);

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            ConfigureCors(app);

            ConfigureErrors(app);

            ConfigureAuth(app, env, Configuration);

            app.UseAntiforgeryToken();

            app.UseMvc();

            ConfigureSwagger(app, env);
        }
    }
}
