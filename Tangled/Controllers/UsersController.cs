using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tangled.Api.DTOs;
using Tangled.Logic.Models;
using Tangled.Logic.Requests;

namespace Tangled.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public UsersController(IMediator mediator, IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }

        [HttpGet]
        public Task<List<UserViewModel>> Get()
        {
            IRequest<List<UserViewModel>> getAllUsersRequest = new GetAllUsersRequest();
            return this.mediator.Send(getAllUsersRequest);
        }

        [HttpPut]
        public Task<UserViewModel> Put(UpdateUserDto dto)
        {
            var request = this.mapper.Map<UpdateUserDto, UpdateUserRequest>(dto);
            return this.mediator.Send(request);
        }

        [HttpPost]
        public Task Post(CreateUserDto dto)
        {
            var request = this.mapper.Map<CreateUserDto, CreateUserRequest>(dto);
            return this.mediator.Send(request);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var request = new DeleteUserRequest
            {
                UserId = id
            };
            await this.mediator.Send(request);

            return this.Ok();
        }

        [HttpGet]
        [Route("{id}")]
        public Task<UserViewModel> Get(int id)
        {
            var request = new GetUserRequest
            {
                UserId = id
            };

            return this.mediator.Send(request);
        }
    }


}