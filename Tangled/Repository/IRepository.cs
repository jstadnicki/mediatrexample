using System.Collections.Generic;
using System.Threading.Tasks;
using Tangled.Api.Database;

namespace Tangled.Api.Repository
{
    internal interface IRepository
    {
        Task<List<User>> GetAllUsersAsync();
        Task DeleteUserByIdAsync(int id);
        Task<User> GetByIdAsync(int id);
        Task CreateUserAsync(User dbUser);
        Task<User> UpdateUserAsync(User dbUser);
    }
}