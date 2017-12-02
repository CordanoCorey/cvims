using System.Net;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using CVIMS.API.Infrastructure.Models;

namespace CVIMS.Api
{
    public partial class Startup
    {
        public static void ConfigureErrors(IApplicationBuilder app)
        {
            app.UseExceptionHandler(builder =>
            {
                builder.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";
                    //UseExceptionHandler calls clear on Response.Headers whixh removes our CORS headers.
                    context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
                    context.Response.Headers.Add("Access-Control-Allow-Headers", "Origin, X-Requested-With, Content-Type, Accept");

                    var error = context.Features.Get<Microsoft.AspNetCore.Diagnostics.IExceptionHandlerFeature>();
                    if (error != null)
                    {
                        await context.Response.WriteAsync(new ErrorResponse { Code = (int)HttpStatusCode.InternalServerError, Message = "An error has occured in the api." + error.Error }.ToString()).ConfigureAwait(false);
                    }
                });
            });
        }
    }
}