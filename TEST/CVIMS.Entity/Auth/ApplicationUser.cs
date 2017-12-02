using CVIMS.Entity.Entities;
using CVIMS.Entity.Lookup;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace CVIMS.Entity.Auth
{
    public partial class ApplicationUser : IdentityUser<string>
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string CellPhone { get; set; }
        public string HomePhone { get; set; }
        public int DefaultLandingPageId { get; set; }
        public bool SendOrderPlacedEmail { get; set; }
        public bool SendOrderPickedEmail { get; set; }
        public bool SendOrderShippedEmail { get; set; }
        public bool SendOrderApprovedEmail { get; set; }
        public bool SendOrderDeniedEmail { get; set; }
        public bool SendOrderCancelledEmail { get; set; }
        public int StateId { get; set; }
        public string StreetAddress { get; set; }
        public int ZipCode { get; set; }
        
        public virtual LandingPage_lkp DefaultLandingPage { get; set; }
        public virtual State_lkp State { get; set; }
    }
}
