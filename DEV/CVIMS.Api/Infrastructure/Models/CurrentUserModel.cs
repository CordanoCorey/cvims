using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVIMS.Api.Infrastructure.Models
{
    public class CurrentUserModel : UserModel
    {
        public int AccessFailedCount { get; set; }
        public string ConcurrencyStamp { get; set; }
        public bool EmailConfirmed { get; set; }
        public DateTime? LastPasswordChangedDate { get; set; }
        public bool LockoutEnabled { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public string NormalizedEmail { get; set; }
        public string NormalizedUserName { get; set; }
        public string Password { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordResetCode { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public string SecurityStamp { get; set; }
        public string ServerSalt { get; set; }
        public bool TwoFactorEnabled { get; set; }
    }
}
