using Autofac;
using Microsoft.EntityFrameworkCore;
using Tangled.Database.Database;
using Tangled.Database.Repository;
using Tangled.Logic.Repositories;

namespace Tangled.Database
{
    public class DatabaseModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            System.Diagnostics.Debug.WriteLine("DatabaseModule");
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