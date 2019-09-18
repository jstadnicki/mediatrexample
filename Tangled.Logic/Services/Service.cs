﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Tangled.Database.Database;
using Tangled.Database.Repository;
using Tangled.Logic.DTOs;
using Tangled.Logic.Models;
using Tangled.Logic.Validators;

namespace Tangled.Logic.Services
{
    class Service : IService
    {
        private readonly IDbRepository _dbRepository;
        private readonly IMapper mapper;
        private readonly CreateUserDtoValidator createValidator;
        private readonly UpdateUserDtoValidator updateValidator;

        public Service(
            IDbRepository dbRepository,
            IMapper mapper,
            CreateUserDtoValidator createValidator,
            UpdateUserDtoValidator updateValidator)
        {
            this._dbRepository = dbRepository;
            this.mapper = mapper;
            this.createValidator = createValidator;
            this.updateValidator = updateValidator;
        }

        public async Task<List<UserViewModel>> GetAllAsync()
        {
            var dbUsers = await this._dbRepository.GetAllUsersAsync();
            var vmUsers = this.mapper.Map<List<User>, List<UserViewModel>>(dbUsers);
            return vmUsers;
        }

        public Task CreateAsync(CreateUserDto dto)
        {
            var validationResult = this.createValidator.Validate(dto);
            if (validationResult.IsValid)
            {
                var dbUser = this.mapper.Map<CreateUserDto, User>(dto);
                return this._dbRepository.CreateUserAsync(dbUser);
            }
            throw new InvalidOperationException(string.Join(',', validationResult.Errors));
        }

        public Task DeleteAsync(int id)
            => this._dbRepository.DeleteUserByIdAsync(id);

        public async Task<UserViewModel> GetAsync(int id)
        {
            var dbUser = await this._dbRepository.GetByIdAsync(id);
            var vmUser = this.mapper.Map<User, UserViewModel>(dbUser);
            return vmUser;
        }

        public async Task<UserViewModel> UpdateAsync(UpdateUserDto dto)
        {
            var validationResult = this.updateValidator.Validate(dto);
            if (validationResult.IsValid)
            {
                var dbUser = this.mapper.Map<UpdateUserDto, User>(dto);
                var updatedUser = await this._dbRepository.UpdateUserAsync(dbUser);
                var resultUser = this.mapper.Map<User, UserViewModel>(updatedUser);
                return resultUser;

            }
            throw new InvalidOperationException(string.Join(',', validationResult.Errors));
        }
    }
}