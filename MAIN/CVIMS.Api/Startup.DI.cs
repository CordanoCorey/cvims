using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using CVIMS.Api.Infrastructure.Auth;
using CVIMS.API.Infrastructure.Services;
using CVIMS.API.Repositories;

namespace CVIMS.Api
{
    public partial class Startup
    {
        public static void ConfigureDIServices(IServiceCollection services)
        {
            //Auth
            services.AddScoped<IClaimsService, ClaimsService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAuthorizationHandler, AccountRequirementHandler>();
        }
    }
}