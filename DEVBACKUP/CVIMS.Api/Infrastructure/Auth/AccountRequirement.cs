using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Routing;
using System.Threading.Tasks;

namespace CVIMS.Api.Infrastructure.Auth
{
    public class AccountRequirementHandler : AuthorizationHandler<AccountRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AccountRequirement requirement)
        {

            var resource = context.Resource as Microsoft.AspNetCore.Mvc.Filters.AuthorizationFilterContext;

            var orgId = resource.HttpContext.GetRouteData().Values["orgId"];

            if (!context.User.HasClaim(x => x.Type == requirement.Role && x.Value == orgId.ToString()))
            {
                return Task.CompletedTask;
            }

            context.Succeed(requirement);
            return Task.CompletedTask;
        }
    }

    public class AccountRequirement : IAuthorizationRequirement
    {
        public int AccountId { get; private set; }
        public string Role { get; private set; }

        public AccountRequirement(int accountId, string role)
        {
            AccountId = accountId;
            Role = role;
        }
    }
}
