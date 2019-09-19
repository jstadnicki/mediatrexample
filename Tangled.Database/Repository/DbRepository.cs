using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Tangled.Database.Database;
using Tangled.Logic.Models;
using Tangled.Logic.Repositories;
using Tangled.Logic.Requests;

namespace Tangled.Database.Repository
{
    class DbRepository : IDbRepository
    {
        private readonly EFContext database;
        private readonly IMapper mapper;

        public DbRepository(EFContext database, IMapper mapper)
        {
            this.database = database;
            this.mapper = mapper;
        }

        public async Task<List<UserViewModel>> GetAllUsersAsync()
        {
            var dbUsers = await this.database.Users.ToListAsync();
            var vmUsers = this.mapper.Map<List<User>, List<UserViewModel>>(dbUsers);
            return vmUsers;
        }

        public async Task DeleteUserByIdAsync(DeleteUserRequest request)
        {
            var user = await this.database.Users.SingleAsync(x => x.Id == request.UserId);
            this.database.Users.Remove(user);
            await this.database.SaveChangesAsync();
        }

        public async Task<UserViewModel> GetByIdAsync(GetUserRequest request)
        {
            var user = await this.database.Users.SingleAsync(x => x.Id == request.UserId);
            var vmUser = this.mapper.Map<User, UserViewModel>(user);
            return vmUser;
        }

        public async Task CreateUserAsync(CreateUserRequest request)
        {
            var dbUser = this.mapper.Map<CreateUserRequest, User>(request);
            await this.database.Users.AddAsync(dbUser);
            await this.database.SaveChangesAsync();
        }

        public async Task<UserViewModel> UpdateUserAsync(UpdateUserRequest request)
        {
            var user = await this.database.Users.SingleAsync(x => x.Id == request.Id);
            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            await this.database.SaveChangesAsync();
            var vmUser = this.mapper.Map<User, UserViewModel>(user);
            return vmUser;
        }
    }
}