using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PracticalWork.DataAccess.Model;

namespace PracticalWork.DataAccess.Context
{
    public class CWContext : IdentityDbContext<User>
    {
        public CWContext(DbContextOptions<CWContext> options) : base(options) { }
        public DbSet<UserPasswords>? UserPasswords { get; set; }

    }
}
