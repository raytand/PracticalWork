using System.ComponentModel.DataAnnotations;

namespace PracticalWork.DataAccess.Model
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Please enter your email.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [UIHint("Email")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Please enter your password.")]
        [DataType(DataType.Password)]
        [UIHint("Password")]
        public string? Password { get; set; }
    }
}
