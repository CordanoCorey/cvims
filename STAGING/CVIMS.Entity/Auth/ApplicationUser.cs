using Microsoft.AspNetCore.Identity;

namespace CVIMS.Entity.Entities
{
    public partial class ApplicationUser : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public bool SendOrderPlacedEmail { get; set; }
    }
}
