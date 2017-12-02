using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CVIMS.Entity.Auth
{
    public class ApplicationRole : IdentityRole<int>
    {
        public int AccountId { get; set; }
    }
}
