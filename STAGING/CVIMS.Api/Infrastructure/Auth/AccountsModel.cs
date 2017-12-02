using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVIMS.Api.Infrastructure.Auth
{
    public class AccountsModel
    {
    }
    public class UserProfileModel
    {

    }

    public class ResetPasswordModel
    {
        public string UserId { get; set; }
        public string Password { get; set; }
    }

    public class CreateUserModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
