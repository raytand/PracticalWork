using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace PracticalWork.DataAccess.Model
{
        public class PasswordsViewModel : UserPasswords
        {
            [Required(ErrorMessage = "You need to enter password")]
            [Display(Name = "Password")]
            public override string? UserPassword { get; set; }

            [Required(ErrorMessage = "You need to enter user name")]
            [Display(Name = "User name that use the password")]
            public override string? UserName { get; set; }

        

           
        }
    
}
