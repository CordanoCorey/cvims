using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using CVIMS.Entity.Entities;
using CVIMS.Entity.Auth;

namespace CVIMS.Api.Infrastructure.Authentication
{
    /// <summary>
    /// Token generator middleware component which is added to an HTTP pipeline.
    /// This class is not created by application code directly,
    /// instead it is added by calling the <see cref="TokenProviderAppBuilderExtensions.UseSimpleTokenProvider(Microsoft.AspNetCore.Builder.IApplicationBuilder, TokenProviderOptions)"/>
    /// extension method.
    /// </summary>
    public class TokenProviderMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly TokenProviderOptions _options;
        private readonly ILogger _logger;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly JsonSerializerSettings _serializerSettings;

        public TokenProviderMiddleware(
            RequestDelegate next,
            IOptions<TokenProviderOptions> options,
            SignInManager<ApplicationUser> sim,
            UserManager<ApplicationUser> um,
            ILoggerFactory loggerFactory)
        {
            _next = next;
            _signInManager = sim;
            _userManager = um;
            _logger = loggerFactory.CreateLogger<TokenProviderMiddleware>();

            _options = options.Value;

            _serializerSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            };
        }

        public Task Invoke(HttpContext context)
        {
            // If the request path doesn't match, skip
            if (!context.Request.Path.Equals(_options.Path, StringComparison.Ordinal))
            {
                return _next(context);
            }

            // Request must be POST with Content-Type: application/x-www-form-urlencoded
            if (!context.Request.Method.Equals("POST")
               || !context.Request.HasFormContentType)
            {
                context.Response.StatusCode = 400;
                return context.Response.WriteAsync("Bad request.");
            }

            _logger.LogInformation("Handling token request: " + context.Request.Path);

            return GenerateToken(context);
        }

        private async Task GenerateToken(HttpContext context)
        {
            var username = context.Request.Form["username"];
            var password = context.Request.Form["password"];

            var signInResult = await _signInManager.PasswordSignInAsync(username, password, true, false);
            List<Claim> userclaims = new List<Claim>();
            if (signInResult.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(username);
                var umClaims = await _userManager.GetClaimsAsync(user);
                userclaims.AddRange(umClaims);
                if (userclaims.All(x => x.Type != "firstName"))
                    userclaims.Add(new Claim("firstName", user.UserName));
                if (userclaims.All(x => x.Type != "lastName"))
                    userclaims.Add(new Claim("lastName", user.UserName));
                if (userclaims.All(x => x.Type != "email"))
                    userclaims.Add(new Claim("email", user.Email));
                /*  sign in manager confirms the pw is good
                 *  usermanager grabs the user and the claims
                 *  claims are shoved into jwt later
                 */
            }
            else
            {
                var err_response = new
                {
                    statusCode = 400,
                    message = "Invalid username or password."
                };
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync(JsonConvert.SerializeObject(err_response, _serializerSettings));
                return;
            }

            var now = DateTime.UtcNow;
            username = username.ToString().ToUpper();
            // Specifically add the jti (nonce), iat (issued timestamp), and sub (subject/user) claims.
            // You can add other claims here, if you want:
            var jwtclaims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, username),
                new Claim(JwtRegisteredClaimNames.Jti, await _options.NonceGenerator()),
                new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(now).ToString(), ClaimValueTypes.Integer64)
            };
            userclaims.AddRange(jwtclaims);



            // Create the JWT and write it to a string
            var jwt = new JwtSecurityToken(
                issuer: _options.Issuer,
                audience: _options.Audience,
                claims: userclaims,
                notBefore: now,
                expires: now.Add(_options.Expiration),
                signingCredentials: _options.SigningCredentials);

            //convert role claims to roles object on jwt payload
            List<AspNetRoles> roles = new List<AspNetRoles>();
            List<string> roleNames = new List<string>
            {
                "Administrator",
                "Author",
                "Viewer"
            };
            foreach (var claim in userclaims)
            {
                if (!roleNames.Contains(claim.Type)) continue;
                roles.Add(new AspNetRoles { Id = claim.Value, Name = claim.Type });
            }

            jwt.Payload.Add("roles", roles);

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                expires_in = (int)_options.Expiration.TotalSeconds
            };

            // Serialize and return the response
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(JsonConvert.SerializeObject(response, _serializerSettings));
        }

        ///// <summary>
        ///// Get this datetime as a Unix epoch timestamp (seconds since Jan 1, 1970, midnight UTC).
        ///// </summary>
        ///// <param name="date">The date to convert.</param>
        ///// <returns>Seconds since Unix epoch.</returns>
        public static long ToUnixEpochDate(DateTime date)
            => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);
    }
}
