using PracticalWork.DataAccess.Model;
using PracticalWork.DataAccess.Context;
using Microsoft.EntityFrameworkCore;

namespace PracticalWork.DataAccess.Repositories
{
    public class PasswordRepositories : IPasswordRepositories
    {
        private CWContext _context;
        public PasswordRepositories(CWContext context)
        {
            _context = context;
        }
        public async Task<List<UserPasswords>> GetUserTasksAsync(string? username)
        {
            return await _context.UserPasswords
                .Where(ut => ut.UserIdFk.UserName == username).ToListAsync();
        }

        public async Task AddTaskAsync(string? username, UserPasswords? passwords)
        {
            var user = await _context.Users.FirstAsync(u => u.UserName == username);
           
            

            _context.UserPasswords?.Add(new UserPasswords()
            {
              UserName = passwords?.UserName,
              UserPassword = passwords?.UserPassword,
              UserIdFk = user
            });

            await _context.SaveChangesAsync();
        }
        public async Task<UserPasswords> FindPasswordByIdAsync(int id)
        {
          
                var res =await _context.UserPasswords
                .FirstAsync(r => r.PasswordId == id);
            return res;
        }
        public async Task DeletePasswordAsync(int id)
        {
            var res = await FindPasswordByIdAsync(id);
             _context.UserPasswords?.Remove(res);
            await _context.SaveChangesAsync();
            
        }
    }
}
