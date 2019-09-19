using System.Collections.Generic;
using System.Threading.Tasks;
using Tangled.Logic.Models;
using Tangled.Logic.Requests;

namespace Tangled.Logic.Repositories
{
    public interface IDbRepository
    {
        Task<List<UserViewModel>> GetAllUsersAsync();
        Task DeleteUserByIdAsync(DeleteUserRequest id);
        Task<UserViewModel> GetByIdAsync(GetUserRequest id);
        Task CreateUserAsync(CreateUserRequest dbUser);
        Task<UserViewModel> UpdateUserAsync(UpdateUserRequest dbUser);
    }
}