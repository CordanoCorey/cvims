using CVIMS.Entity.Lookup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVIMS.Api.Infrastructure.Models
{
    public class UserModel : BaseEntity
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

        public virtual ILookup DefaultLandingPage { get; set; }
        public virtual ILookup State { get; set; }
    }
}
