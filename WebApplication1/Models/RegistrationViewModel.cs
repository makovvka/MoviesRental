using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class RegistrationViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "First name has to be provided. ")]
        [MaxLength(50, ErrorMessage = "Max 50 characters")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name has to be provided. ")]
        [MaxLength(50, ErrorMessage = "Max 50 characters")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email has to be provided. ")]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please Enter Valid Email.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Username is required ")]
        [MaxLength(20, ErrorMessage = "Max 20 characters")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password is required. ")]
        [MaxLength(20, ErrorMessage = "Max 20 characters")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [MaxLength(5, ErrorMessage = "Max 5 characters allowed.")]
        public string Role { get; set; } = "USER";

        [Compare("Password", ErrorMessage = "Please confirm your password.")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Max 20 characters, min 5")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; } 
    }
}
