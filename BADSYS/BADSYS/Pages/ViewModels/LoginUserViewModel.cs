using System.ComponentModel.DataAnnotations;

namespace BADSYS.Pages.ViewModels
{
    public class LoginUserViewModel
    {
        public LoginUserViewModel()
        {

        }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
