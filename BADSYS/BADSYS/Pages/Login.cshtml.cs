using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using DLL;
using DAL.UserBranch;
using BADSYS.Pages.ViewModels;

namespace BADSYS.Pages.UserManagement
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public LoginUserViewModel LoginUserViewModel { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                // login with email
                UserManager userManager = new UserManager(new UserDAL());
                bool result = userManager.Login(LoginUserViewModel.Email, LoginUserViewModel.Password);
                if (result)
                {

                    List<Claim> claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.Email, LoginUserViewModel.Email));
                    claims.Add(new Claim(ClaimTypes.Role, "User"));

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    HttpContext.SignInAsync(new ClaimsPrincipal(claimsIdentity));

                    return RedirectToPage("Index");
                }
                else
                {
                    ModelState.AddModelError("LogOnError", "The Email/Username or Password provided is incorrect.");
                    return Page();
                }
            }
            else
            {
                return Page();
            }

        }
    }
}
