using AutoMapper;
using Tangled.Database.Database;
using Tangled.Logic.DTOs;
using Tangled.Logic.Models;

namespace Tangled.Logic
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            this.CreateMap<CreateUserDto, User>();
            this.CreateMap<UpdateUserDto, User>();
            this.CreateMap<User, UserViewModel>();
        }
    }
}
