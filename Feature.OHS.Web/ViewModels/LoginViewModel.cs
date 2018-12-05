using System.ComponentModel.DataAnnotations;

namespace Feature.OHS.Web.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Please enter your email address as your {0}")]
        [DataType(DataType.EmailAddress)]
        public string UserName { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(20)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class UpdatePasswordResetTokenModel
    {
        public int UserId { get; set; }
        public string ResetToken { get; set; }
    }
}
