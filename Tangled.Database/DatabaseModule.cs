using Autofac;
using Microsoft.EntityFrameworkCore;
using Tangled.Database.Database;
using Tangled.Database.Repository;

namespace Tangled.Database
{
    public class DatabaseModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
           builder.RegisterType<DbRepository>().As<IDbRepository>();

            builder.Register(c =>
            {
                var opt = new DbContextOptionsBuilder<EFContext>();
                opt.UseInMemoryDatabase("tangled");
                return new EFContext(opt.Options);
            }).As<EFContext>();
        }
    }


}