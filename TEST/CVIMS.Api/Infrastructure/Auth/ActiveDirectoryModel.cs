using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVIMS.Api.Infrastructure.Auth
{
    public class ActiveDirectoryModel
    {
    }

    public class ActiveDirectoryConfigModel
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public int Version { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
