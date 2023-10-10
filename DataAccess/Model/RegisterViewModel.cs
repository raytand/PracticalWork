using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PracticalWork.DataAccess.Context;
using System.ComponentModel.DataAnnotations;

namespace PracticalWork.DataAccess.Model
{

    public class RegisterViewModel
    {
        [Required(ErrorMessage ="You need to enter your Email")]
        [EmailAddress]
        public string? Email { get; set; }

        [Required(ErrorMessage = "You need to enter your first name")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "You need to enter your last name")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "You need to create password")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Required(ErrorMessage ="You need to confirm your password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string? PasswordConfirmation { get; set; }
    }

}
