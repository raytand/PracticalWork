using System.ComponentModel.DataAnnotations;

namespace PracticalWork.DataAccess.Model
{
    public class UserPasswords
    {

        [Key]
            public int PasswordId { get; set; }
            public virtual string? UserPassword { get; set; }
            public virtual string? UserName { get; set; }
            public User? UserIdFk { get; set; }
        
    }
}
