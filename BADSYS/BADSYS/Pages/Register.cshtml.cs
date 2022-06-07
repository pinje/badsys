using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BADSYS.Pages.ViewModels;
using DLL;
using DAL.UserBranch;
using Models;

namespace BADSYS.Pages
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public RegisterUserViewModel RegisterUserViewModel { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            // check email uniqueness
            UserManager userManager = new UserManager(new UserDAL());
            List<User> users = userManager.GetAllUsers();

            if (users.Any(x => x.Email == RegisterUserViewModel.Email))
            {
                // not unique, cannot register
                ModelState.AddModelError("Uniqueness", $"A user with this email address already exists");
            }

            if (ModelState.IsValid)
            {
                User user = new User(RegisterUserViewModel.Firstname, RegisterUserViewModel.Lastname, RegisterUserViewModel.Email, "default.jpg");
                userManager.AddUser(user, RegisterUserViewModel.Password);
                return RedirectToPage("Login");
            }
            else
            {
                return Page();
            }
        }
    }
}
