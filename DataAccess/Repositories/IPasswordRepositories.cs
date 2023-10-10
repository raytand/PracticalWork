using PracticalWork.DataAccess.Model;

namespace PracticalWork.DataAccess.Repositories
{
    public interface IPasswordRepositories
    {
        Task<List<UserPasswords>> GetUserTasksAsync(string? username);
        Task AddTaskAsync(string? username, UserPasswords? passwords);
        Task<UserPasswords> FindPasswordByIdAsync(int id);
        Task DeletePasswordAsync(int id);
    }
}
