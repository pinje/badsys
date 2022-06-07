using System.ComponentModel.DataAnnotations;

namespace BADSYS.Pages.ViewModels
{
    public class RegisterUserViewModel
    {
        public RegisterUserViewModel()
        {

        }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Max 50 characters")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Please enter valid letters")]
        public string Firstname { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Max 50 characters")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Please enter valid letters")]
        public string Lastname { get; set; }
        [Required]
        [MinimumLength(ErrorMessage = "Minimum 8 characters")]
        [UppercaseCheck(ErrorMessage = "At least 1 uppercase English letter")]
        [LowercaseCheck(ErrorMessage = "At least 1 lowercase English letter")]
        [OneDigit(ErrorMessage = "At least 1 digit")]
        [OneSpecialCharacter(ErrorMessage = "At least 1 special character: #?!@$%^&*-")]
        public string Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage = ("Your 'Password' and 'Confirm Password' do not match."))]
        public string ConfirmPassword { get; set; }
    }

    public class MinimumLength : RegularExpressionAttribute
    {
        public MinimumLength()
            : base("^.{8,}")
        {

        }
    }

    public class UppercaseCheck : RegularExpressionAttribute
    {
        public UppercaseCheck()
            : base("(?:(?=.*[A-Z]).*)")
        {

        }
    }

    public class LowercaseCheck : RegularExpressionAttribute
    {
        public LowercaseCheck()
            : base("(?:(?=.*[a-z]).*)")
        {

        }
    }

    public class OneDigit : RegularExpressionAttribute
    {
        public OneDigit()
            : base("(?:(?=.*[0-9]).*)")
        {

        }
    }

    public class OneSpecialCharacter : RegularExpressionAttribute
    {
        public OneSpecialCharacter()
            : base("(?:(?=.*[#?!@$%^&*-]).*)")
        {

        }
    }

}
