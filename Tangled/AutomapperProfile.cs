using AutoMapper;
using Tangled.Api.Database;
using Tangled.Api.DTOs;
using Tangled.Api.Models;

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
