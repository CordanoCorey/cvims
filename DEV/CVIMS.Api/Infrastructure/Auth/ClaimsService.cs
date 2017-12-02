using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;


namespace CVIMS.Api.Infrastructure.Services
{
    public interface IClaimsService
    {
        List<int> GetAllViewerRoles(List<Claim> claims);
    }
    public class ClaimsService : IClaimsService
    {
        public List<int> GetAllViewerRoles(List<Claim> claims)
        {
            if (claims == null) return new List<int>();

            return (from c in claims
                    where (c.Type == "Viewer" || c.Type == "Author" || c.Type == "Administrator")
                    select int.Parse(c.Value)).ToList();
        }

        public List<int> GetAllAuthorRoles(List<Claim> claims)
        {
            if (claims == null) return new List<int>();

            return (from c in claims
                    where (c.Type == "Author" || c.Type == "Administrator")
                    select int.Parse(c.Value)).ToList();
        }

        public List<int> GetAllAdminRoles(List<Claim> claims)
        {
            if (claims == null) return new List<int>();

            return (from c in claims
                    where c.Type == "Administrator"
                    select int.Parse(c.Value)).ToList();
        }

    }
}