using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using CVIMS.Api.Infrastructure.Auth;
using CVIMS.Api.Infrastructure.Authentication;
using CVIMS.Entity.Auth;
using CVIMS.Entity.Context;
using CVIMS.Entity.Entities;
using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CVIMS.Api
{
    public partial class Startup
    {
        public static void ConfigureAuthServices(IConfiguration Configuration, IServiceCollection services)
        {
            var secretKey = Configuration["Auth:SimpleJwt:Secret"];
            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));
           

            var tokenValidationParameters = new TokenValidationParameters
            {
                // The signing key must match!
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = signingKey,

                // Validate the JWT Issuer (iss) claim
                ValidateIssuer = true,
                ValidIssuer = Configuration["Auth:SimpleJwt:Issuer"],

                // Validate the JWT Audience (aud) claim
                ValidateAudience = true,
                ValidAudience = Configuration["Auth:SimpleJwt:Audience"],

                // Validate the token expiry
                ValidateLifetime = true,

                // If you want to allow a certain amount of clock drift, set that here:
                ClockSkew = TimeSpan.Zero
            };
            //Auth
            services.AddAuthentication().AddJwtBearer(options =>
            {
                options.IncludeErrorDetails = true;
                options.TokenValidationParameters = tokenValidationParameters;
                options.Events = new JwtBearerEvents
                {
                    OnChallenge = context =>
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        return Task.FromResult(0);
                    },
                };
            });

            services.AddDbContext<CVIMSContext>(options
                => options.UseSqlServer(Configuration.GetConnectionString("cvims")));

            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<CVIMSContext>().AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(opts =>
            {
                //opts.
                opts.Password.RequireDigit = false;
                opts.Password.RequiredLength = 8;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireLowercase = false;

                opts.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                opts.Lockout.MaxFailedAccessAttempts = 30;
                
                opts.User.RequireUniqueEmail = true;
                
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Administrator", policy => policy.AddRequirements(new AccountRequirement(0, "Administrator")));
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Author", policy => policy.AddRequirements(new AccountRequirement(0, "Author")));
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Viewer", policy => policy.AddRequirements(new AccountRequirement(0, "Viewer")));
            });
        }

        public static void ConfigureAuth(IApplicationBuilder app, IHostingEnvironment env, IConfiguration config)
        {
            app.UseAuthentication();
            //app.UseGoogleAuthentication(new GoogleOptions
            //{
            //    ClientId = "599829567035-sehak91sbr47n2vdg370o60ehjn1nnso.apps.googleusercontent.com",
            //    ClientSecret = "1UCIgzl0ZmMHKKfg4PWf1KrI"
            //});

            var secretKey = config["Auth:SimpleJwt:Secret"];
            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));
            var signCreds = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
            var tokenOptions = new TokenProviderOptions
            {
                Path = "/api/token",
                Audience = config["Auth:SimpleJwt:Audience"],
                Issuer = config["Auth:SimpleJwt:Issuer"],
                SigningCredentials = signCreds,
                Expiration = TimeSpan.FromDays(30)
            };

            app.UseSimpleTokenProvider(tokenOptions);
        }
    }
}