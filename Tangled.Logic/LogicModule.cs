using Autofac;
using Tangled.Logic.Validators;

namespace Tangled.Logic
{
    public class LogicModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes().AsImplementedInterfaces();
            builder.RegisterType<CreateUserDtoValidator>();
            builder.RegisterType<UpdateUserDtoValidator>();
        }
    }
}