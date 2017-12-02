using System;
using System.Collections.Generic;

namespace CVIMS.Entity.Entities
{
    public partial class AspNetUserClaims
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
