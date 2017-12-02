using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CVIMS.Api.Infrastructure
{
    public class ClaimsAuthorizationAttribute : IAsyncActionFilter
    {
        public string ClaimType { get; set; }

        public async Task OnActionExecutionAsync(ActionExecutingContext actionContext, ActionExecutionDelegate next)
        {
            var principal = actionContext.HttpContext.User as ClaimsPrincipal;
            var orgheader = actionContext.HttpContext.Request.Headers.FirstOrDefault(x => x.Key == "x-organization-id");
            string orgId = orgheader.Value.FirstOrDefault();

            if (!string.IsNullOrEmpty(actionContext.HttpContext.Request.Headers["x-organization-id"]) || string.IsNullOrEmpty(orgId) || string.Equals(orgId, "0"))
            {
                actionContext.Result = new BadRequestResult();
            }

            if (principal != null && !principal.Identity.IsAuthenticated)
            {
                actionContext.Result = new UnauthorizedResult();
            }

            if (principal != null && !principal.HasClaim(x => x.Type == ClaimType && x.Value == orgId))
            {
                actionContext.Result = new ForbidResult();
            }
            await next();
        }
    }
}