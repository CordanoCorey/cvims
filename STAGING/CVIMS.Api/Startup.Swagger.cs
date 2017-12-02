using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using CVIMS.Api.Infrastructure.Filters;
using Swashbuckle.AspNetCore.Swagger;

namespace CVIMS.Api
{
    public partial class Startup
    {
        public static void ConfigureSwaggerServices(IServiceCollection services)
        {

            //Swagger
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "CVIMS API",
                    Description = "CVIMS Project",
                    TermsOfService = "None",
                });
                options.DocInclusionPredicate((docName, apiDesc) =>
                {
                    if (apiDesc.HttpMethod == null) return false;
                    return true;
                });
                options.DescribeAllEnumsAsStrings();

                options.OperationFilter<AuthorizationHeaderParameterOperationFilter>();
            });
        }

        public static void ConfigureSwagger(IApplicationBuilder app, IHostingEnvironment env)
        {
            //Swagger
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "CVIMS API");
            });
        }
    }
}