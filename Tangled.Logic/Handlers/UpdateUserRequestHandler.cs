using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Tangled.Database.Database;
using Tangled.Database.Repository;
using Tangled.Logic.Models;
using Tangled.Logic.Requests;
using Tangled.Logic.Validators;

namespace Tangled.Logic.Handlers
{
    public class UpdateUserRequestHandler : IRequestHandler<UpdateUserRequest,UserViewModel>
    {
        private readonly UpdateUserDtoValidator updateValidator;
        private readonly IMapper mapper;
        private readonly IDbRepository dbRepository;

        public UpdateUserRequestHandler(UpdateUserDtoValidator updateValidator, IMapper mapper, IDbRepository dbRepository)
        {
            this.updateValidator = updateValidator;
            this.mapper = mapper;
            this.dbRepository = dbRepository;
        }

        public async Task<UserViewModel> Handle(
            UpdateUserRequest request, 
            CancellationToken cancellationToken)
        {
            var validationResult = this.updateValidator.Validate(request);
            if (validationResult.IsValid)
            {
                var dbUser = this.mapper.Map<UpdateUserRequest, User>(request);
                var updatedUser = await this.dbRepository.UpdateUserAsync(dbUser);
                var resultUser = this.mapper.Map<User, UserViewModel>(updatedUser);
                return resultUser;
            }
            throw new InvalidOperationException(string.Join(',', validationResult.Errors));
        }
    }
}