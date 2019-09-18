using Microsoft.EntityFrameworkCore;

namespace Tangled.Database.Database
{
    public class EFContext : DbContext
    {
        public EFContext(DbContextOptions<EFContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
    }
}