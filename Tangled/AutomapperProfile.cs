using AutoMapper;
using Tangled.Database.Database;
using Tangled.Logic.DTOs;
using Tangled.Logic.Models;

namespace Tangled.Api
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<CreateUserDto, User>();
            CreateMap<UpdateUserDto, User>();
            CreateMap<User, UserViewModel>();
        }
    }
}
