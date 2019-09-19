using AutoMapper;
using Tangled.Database.Database;
using Tangled.Logic.Models;
using Tangled.Logic.Requests;

namespace Tangled.Logic
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            this.CreateMap<CreateUserRequest, User>();
            this.CreateMap<UpdateUserRequest, User>();
            this.CreateMap<User, UserViewModel>();
        }
    }
}
