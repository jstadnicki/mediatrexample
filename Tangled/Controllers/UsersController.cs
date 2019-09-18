using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tangled.Logic.DTOs;
using Tangled.Logic.Models;
using Tangled.Logic.Services;

namespace Tangled.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IService service;

        public UsersController(IService service)
            => this.service = service;

        [HttpGet]
        public Task<List<UserViewModel>> Get()
            => this.service.GetAllAsync();

        [HttpPut]
        public Task<UserViewModel> Put(UpdateUserDto dto)
            => this.service.UpdateAsync(dto);

        [HttpPost]
        public Task Post(CreateUserDto dto)
            => this.service.CreateAsync(dto);

        [HttpDelete]
        public Task Delete(int id)
            => this.service.DeleteAsync(id);

        [HttpGet]
        [Route("{id}")]
        public Task<UserViewModel> Get(int id)
            => this.service.GetAsync(id);
    }
}