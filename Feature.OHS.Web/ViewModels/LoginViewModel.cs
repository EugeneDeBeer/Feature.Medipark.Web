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
}
