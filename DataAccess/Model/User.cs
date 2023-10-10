using Microsoft.AspNetCore.Identity;

namespace PracticalWork.DataAccess.Model
{
    public class User : IdentityUser
    {
         public string? FirstName { get; set; }
        public string? LastName { get; set; }
        
    }
}
