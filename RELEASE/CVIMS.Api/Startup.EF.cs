using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CVIMS.Entity.Context;

namespace CVIMS.Api
{
    public partial class Startup
    {
        public static void ConfigureEFServices(IConfiguration Configuration, IServiceCollection services)
        {
            //EF
            services.AddDbContext<CVIMSContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("seed"));
            });

            services.AddEntityFrameworkSqlServer().AddDbContext<CVIMSContextRO>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("seedro"));
            });
        }
    }
}