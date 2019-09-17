using Microsoft.EntityFrameworkCore;

namespace Tangled.Api.Database
{
    internal class EFContext : DbContext
    {
        public EFContext(DbContextOptions<EFContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
    }
}