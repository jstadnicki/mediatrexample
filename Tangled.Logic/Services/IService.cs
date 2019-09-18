using System.Collections.Generic;
using System.Threading.Tasks;
using Tangled.Logic.DTOs;
using Tangled.Logic.Models;

namespace Tangled.Logic.Services
{
    public interface IService
    {
        Task<List<UserViewModel>> GetAllAsync();
        Task CreateAsync(CreateUserDto createUserDto);
        Task DeleteAsync(int id);
        Task<UserViewModel> GetAsync(int id);
        Task<UserViewModel> UpdateAsync(UpdateUserDto updateUserDto);
    }
}