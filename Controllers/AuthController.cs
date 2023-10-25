/***************************************************************************************
 *    Title: <Microsoft Account external login setup with ASP.NET Core>
 *    Author: <Microsoft>
 *    Date Published: <06 March 2022>
 *    Date Retrieved: <22 October 2023>
 *    Code version: <1.0.0>
 *    Availability: <https://learn.microsoft.com/en-us/aspnet/core/security/authentication/social/microsoft-logins?view=aspnetcore-7.0>
 *
 ***************************************************************************************/

/***************************************************************************************
 *    Title: <Introduction to Identity on ASP.NET Core>
 *    Author: <Microsoft>
 *    Date Published: <12 January 2022>
 *    Date Retrieved: <22 October 2023>
 *    Code version: <1.0.0>
 *    Availability: <https://learn.microsoft.com/en-us/aspnet/core/security/authentication/identity?view=aspnetcore-7.0&tabs=visual-studio>
 *
 ***************************************************************************************/

/***************************************************************************************
 *    Title: <Overview of the Microsoft Authentication Library (MSAL)>
 *    Author: <Microsoft>
 *    Date Published: <10 December 2022>
 *    Date Retrieved: <22 October 2023>
 *    Code version: <1.0.0>
 *    Availability: <https://learn.microsoft.com/en-us/azure/active-directory/develop/msal-overview>
 *
 ***************************************************************************************/

using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.MicrosoftAccount;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC_Microsoft_Login.Models;

namespace MVC_Microsoft_Login.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult SignIn()
        {
            // Trigger Microsoft authentication
            return Challenge(new AuthenticationProperties { RedirectUri = Url.Action("UserProfile", "Auth") }, MicrosoftAccountDefaults.AuthenticationScheme);
        }

        public IActionResult UserProfile()
        {
            // Retrieve the user's name from the Microsoft authentication data
            var userName = User.Identity.Name; // The user's name is stored in the identity.

            // Create a UserModel with the user's name
            var userModel = new UserModel
            {
                UserName = userName
            };

            return View(userModel);
        }

        public IActionResult SignOut()
        {
            var redirectUrl = Url.Action("Index", "Home"); // The redirection URL
            return SignOut(new AuthenticationProperties { RedirectUri = redirectUrl },
                CookieAuthenticationDefaults.AuthenticationScheme);
        }

    }
}
