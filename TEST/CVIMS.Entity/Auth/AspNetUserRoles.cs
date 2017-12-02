using System;
using System.Collections.Generic;

namespace CVIMS.Entity.Auth
{
    public partial class AspNetUserRoles
    {
        public string UserId { get; set; }
        public string RoleId { get; set; }

        public virtual AspNetRoles Role { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
