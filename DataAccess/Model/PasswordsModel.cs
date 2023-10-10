using System.ComponentModel.DataAnnotations;


namespace PracticalWork.DataAccess.Model
{
    public class PasswordsModel
    {
        [Key]
        public int PWId { get; set; }


        [Required(ErrorMessage ="You need to enter the user name or email")]
        public virtual string? UserName { get; set; }

        
        [Required(ErrorMessage ="You need to enter password")]
        public virtual string? UserPassword{ get; set; }

        
    }
}
