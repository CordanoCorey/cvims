using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Novell.Directory.Ldap;
using Microsoft.Extensions.Options;

namespace CVIMS.Api.Infrastructure.Auth
{
    [Produces("application/json")]
    [Route("api/ActiveDirectoryAuth")]
    public class ActiveDirectoryAuthController : Controller
    {
        private readonly ActiveDirectoryConfigModel _config;

        public ActiveDirectoryAuthController(IOptions<ActiveDirectoryConfigModel> config)
        {
            _config = config.Value;
        }
        // POST: api/ActiveDirectoryAuth
        [HttpPost]
        public void Post([FromBody]string username, string password)
        {
            LdapConnection conn = new LdapConnection();
            conn.Connect(_config.Host, _config.Port);
            conn.Bind(_config.Version, _config.UserName, _config.Password);

            LdapAttribute attr = new LdapAttribute("userPassword", password);
            bool correct = conn.Compare(username, attr);
        }
    }
}
