using System.Collections.Generic;
using Autofac;
using MediatR;
using Tangled.Logic.Handlers;
using Tangled.Logic.Models;
using Tangled.Logic.Pipelines;
using Tangled.Logic.Requests;
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
            builder.RegisterType<CreateUserRequestHandler>().As<IRequestHandler<CreateUserRequest, RequestResult>>();
            builder.RegisterType<GetUserRequestHandler>().As<IRequestHandler<GetUserRequest, UserViewModel>>();
            builder.RegisterType<GetAllUsersRequestHandler>().As<IRequestHandler<GetAllUsersRequest, List<UserViewModel>>>();

            builder.RegisterType<GetAllUsersRequestHandler>().As<IRequestHandler<GetAllUsersRequest, List<UserViewModel>>>();
            builder.RegisterGeneric(typeof(ValidationBehavior<,>)).As(typeof(IPipelineBehavior<,>));

        }
    }
}