using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Username or Email is required ")]
        [MaxLength(20, ErrorMessage = "Max 20 characters")]
        [DisplayName("Username or Email")]
        public string UserNameOrEmail { get; set; }
        [Required(ErrorMessage = "Password is required. ")]
        [MaxLength(20, ErrorMessage = "Max 20 characters")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
