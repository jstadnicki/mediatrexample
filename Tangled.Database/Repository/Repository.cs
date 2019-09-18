using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tangled.Database.Database;

namespace Tangled.Database.Repository
{
    class Repository : IRepository
    {
        private readonly EFContext database;

        public Repository(EFContext database)
        {
            this.database = database;
        }

        public Task<List<User>> GetAllUsersAsync() 
            => this.database.Users.ToListAsync();

        public async Task DeleteUserByIdAsync(int id)
        {
            var user = await this.database.Users.SingleAsync(x => x.Id == id);
            this.database.Users.Remove(user);
            await this.database.SaveChangesAsync();
        }

        public Task<User> GetByIdAsync(int id) 
            => this.database.Users.SingleAsync(x => x.Id == id);

        public async Task CreateUserAsync(User dbUser)
        {
            await this.database.Users.AddAsync(dbUser);
            await this.database.SaveChangesAsync();
        }

        public async Task<User> UpdateUserAsync(User dbUser)
        {
            var user = await this.GetByIdAsync(dbUser.Id);
            user.FirstName = dbUser.FirstName;
            user.LastName = dbUser.LastName;
            await this.database.SaveChangesAsync();
            return user;
        }
    }
}