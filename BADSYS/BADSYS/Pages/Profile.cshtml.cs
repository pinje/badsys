using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;
using DLL;
using DAL.UserBranch;

namespace BADSYS.Pages
{
    public class ProfileModel : PageModel
    {
        [BindProperty]
        public User User { get; set; }
        public void OnGet(int userid)
        {
            UserManager userManager = new UserManager(new UserDAL());
            User = userManager.GetUser(userid);
        }
    }
}
