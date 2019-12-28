using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Assistant.Helpers;
using Assistant.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Assistant.Pages
{
    public class LoginModel : PageModel
    {
        public LoginModel(ICourseUserService courseUserService)
        {
            CourseUserService = courseUserService;
        }
        public string ReturnUrl { get; set; }
        public ICourseUserService CourseUserService { get; }

        public async Task<IActionResult>
            OnGetAsync(string paramUsername, string paramPassword)
        {
            string returnUrl = Url.Content("~/");
            var user = await CourseUserService.LoginAsync(paramUsername, paramPassword);
            if (user != null)
            {
                try
                {
                    // Clear the existing external cookie
                    await HttpContext
                        .SignOutAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme);
                }
                catch { }
                // *** !!! This is where you would validate the user !!! ***
                // In this example we just log the user in
                // (Always log the user in for this demo)
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Account),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, GlobalHelper.UserRoleName),
                };

                if (user.IsAdmin == true)
                {
                    
                    claims.Add(new Claim(ClaimTypes.Role, GlobalHelper.AdminRoleName));
                }
                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true,
                    RedirectUri = this.Request.Host.Value
                };
                try
                {
                    await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);
                }
                catch (Exception ex)
                {
                    string error = ex.Message;
                }
            }
            return LocalRedirect(returnUrl);
        }
    }
}
