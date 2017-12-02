using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using CVIMS.Api.Infrastructure.Auth;
using CVIMS.Api.Infrastructure.Mapper;
using CVIMS.Api.Infrastructure.Config;

namespace CVIMS.Api
{
    public partial class Startup
    {
        private const string ALLOW_SPECIFIC_ORIGIN = "AllowSpecificOrigin";
        private MapperConfiguration _mapperConfiguration { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;//Set up AutoMapper
            _mapperConfiguration = new MapperConfiguration(config =>
            {
                config.AddProfile(new AutoMapperConfiguration());
                config.AddProfile(new CurrentUserMapProfile());
                config.AddProfile(new CartItemMapProfile());
                config.AddProfile(new CategoryMapProfile());
                config.AddProfile(new FavoriteMapProfile());
                config.AddProfile(new OrderMapProfile());
                config.AddProfile(new OrderStatusMapProfile());
                config.AddProfile(new ProductMapProfile());
                config.AddProfile(new ProductImageMapProfile());
                config.AddProfile(new ProductLookupValueMapProfile());
            });
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureCorsServices(Configuration, services);

            ConfigureEFServices(Configuration, services);

            services.AddAntiforgery(options => options.HeaderName = "X-XSRF-TOKEN");

            //services.AddMvc();

            services.AddAutoMapper();

            ConfigureAuthServices(Configuration, services);

            ConfigureSwaggerServices(services);

            ConfigureDIServices(services);

            services.AddMvc();

            services.AddOptions();

            services.Configure<SquarePaymentConfigModel>(Configuration.GetSection("Square"));

            services.Configure<ActiveDirectoryConfigModel>(Configuration.GetSection("ldap"));
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
