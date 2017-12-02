using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using CVIMS.Api.Infrastructure.Auth;
using CVIMS.Entity.Entities;
using System;
using System.Threading.Tasks;
using CVIMS.Entity.Auth;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CVIMS.Api.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            return Challenge();
        }

        [AllowAnonymous]
        public IActionResult LoginFacebook(string returnUrl)
        {
            return Challenge();
        }

        [AllowAnonymous]
        public IActionResult LoginGoogle(string returnUrl)
        {
            var redirectUrl = Url.Action("LoginGoogleCallBack", "Account", returnUrl);
            var props = _signInManager.ConfigureExternalAuthenticationProperties("Google", redirectUrl);

            return Challenge(props);
        }

        [AllowAnonymous]
        public async Task<ApplicationUser> LoginGoogleCallback(string returnUrl, string serviceError)
        {

            if (serviceError == null)
            {
                var info = await _signInManager.GetExternalLoginInfoAsync();
                if (info != null)
                {
                    var result = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, false);
                    if (result.Succeeded)
                    {
                        return await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);
                    }
                }
            }

            throw new Exception($"Login Failed:{serviceError}");
        }

        public async void Logout()
        {
            await _signInManager.SignOutAsync();
        }

        [HttpPost]
        [Route("CreateUser")]
        public async Task<ApplicationUser> CreateUser(CreateUserModel model)
        {

            var user = new ApplicationUser();
            user.UserName = model.Email;
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Email = model.Email;

            var newUser = await _userManager.CreateAsync(user);

            if (newUser.Succeeded)
            {
                string resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
                IdentityResult passwordChangeResult = await _userManager.ResetPasswordAsync(user, resetToken, model.Password);
            }

            return user;
        }

        //This is a shortcut.  It will work for smaller in house apps.  It will simply overwrite the password with the one supplied in the model.
        //Ideally the token would be sent via email then the user would click a link to the reset password endpoint.
        [HttpPost]
        [Route("ChangePassword")]
        public async Task<ApplicationUser> ResetPassword(ResetPasswordModel model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);
            string resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            IdentityResult passwordChangeResult = await _userManager.ResetPasswordAsync(user, resetToken, model.Password);

            return user;
        }
        //update profile
    }
}
