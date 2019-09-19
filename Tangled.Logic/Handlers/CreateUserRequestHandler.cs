﻿using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Tangled.Database.Database;
using Tangled.Database.Repository;
using Tangled.Logic.Requests;
using Tangled.Logic.Validators;

namespace Tangled.Logic.Handlers
{
    public class CreateUserRequestHandler : IRequestHandler<CreateUserRequest>
    {
        private readonly CreateUserDtoValidator createValidator;
        private readonly IMapper mapper;
        private readonly IDbRepository dbRepository;

        public CreateUserRequestHandler(
            CreateUserDtoValidator createValidator, 
            IMapper mapper, 
            IDbRepository dbRepository)
        {
            this.createValidator = createValidator;
            this.mapper = mapper;
            this.dbRepository = dbRepository;
        }

        public Task<Unit> Handle(
            CreateUserRequest request, 
            CancellationToken cancellationToken)
        {
            var validationResult = this.createValidator.Validate(request);
            if (validationResult.IsValid)
            {
                var dbUser = this.mapper.Map<CreateUserRequest, User>(request);
                this.dbRepository.CreateUserAsync(dbUser);
                return Task.FromResult(new Unit());
            }
            throw new InvalidOperationException(string.Join(',', validationResult.Errors));
        }
    }
}