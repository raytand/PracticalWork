using Microsoft.AspNetCore.Identity;
using PracticalWork.DataAccess.Model;

namespace PracticalWork.DataAccess.Repositories
{
    public interface IPasswordRepositories
    {
        Task<List<UserPasswords>> GetPasswordAsync(string? username);
        Task AddPasswordAsync(string? username, UserPasswords? passwords);
        Task<UserPasswords> FindPasswordByIdAsync(int id);
        Task DeletePasswordAsync(int id);
        Task UpdatePasswordAsync(UserPasswords passwords);
        Task<bool> PasswordExists(int id);
        Task<User?> FindUserByIdAsync(string? id);
    }
}
