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
        public void Post(string username, string password)
        {
            LdapConnection conn = new LdapConnection();
            conn.SecureSocketLayer = true;

            conn.UserDefinedServerCertValidationDelegate += new RemoteCertificateValidationCallback((sender, certificate, chain, policyErrors) => { return true; });

            conn.Connect(_config.Host, _config.Port);
            conn.Bind(_config.DN, _config.Password);

            LdapAttribute attr = new LdapAttribute("userPassword", password);
            bool correct = conn.Compare("cn=" + username + ",ou=SUPPORT,o=CVSD", attr);
        }
    }
}
