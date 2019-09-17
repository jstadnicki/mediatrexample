using System.Collections.Generic;
using System.Threading.Tasks;
using Tangled.Api.DTOs;
using Tangled.Api.Models;

namespace Tangled.Api.Services
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