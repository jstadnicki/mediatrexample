using AutoMapper;
using Tangled.Api.DTOs;
using Tangled.Logic.Requests;

namespace Tangled.Api
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            this.CreateMap<UpdateUserDto, UpdateUserRequest>();
            this.CreateMap<CreateUserDto, CreateUserRequest>();
        }
    }
}
