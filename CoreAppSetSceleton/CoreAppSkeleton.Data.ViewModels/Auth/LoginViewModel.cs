using System.ComponentModel.DataAnnotations;

namespace CoreAppSkeleton.Data.ViewModels.Auth
{
    public class LoginViewModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}