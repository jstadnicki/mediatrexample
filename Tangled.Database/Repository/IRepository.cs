using System.Collections.Generic;
using System.Threading.Tasks;
using Tangled.Database.Database;

namespace Tangled.Database.Repository
{
    public interface IRepository
    {
        Task<List<User>> GetAllUsersAsync();
        Task DeleteUserByIdAsync(int id);
        Task<User> GetByIdAsync(int id);
        Task CreateUserAsync(User dbUser);
        Task<User> UpdateUserAsync(User dbUser);
    }
}