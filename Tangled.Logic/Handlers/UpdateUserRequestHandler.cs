using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Tangled.Logic.Models;
using Tangled.Logic.Repositories;
using Tangled.Logic.Requests;
using Tangled.Logic.Validators;

namespace Tangled.Logic.Handlers
{
    public class UpdateUserRequestHandler : IRequestHandler<UpdateUserRequest, UserViewModel>
    {
        private readonly UpdateUserDtoValidator updateValidator;
        private readonly IDbRepository dbRepository;

        public UpdateUserRequestHandler(
            UpdateUserDtoValidator updateValidator, 
            IDbRepository dbRepository)
        {
            this.updateValidator = updateValidator;
            this.dbRepository = dbRepository;
        }

        public async Task<UserViewModel> Handle(
            UpdateUserRequest request,
            CancellationToken cancellationToken)
        {
            var validationResult = this.updateValidator.Validate(request);
            if (validationResult.IsValid)
            {
                var updatedUser = await this.dbRepository.UpdateUserAsync(request);
                return updatedUser;
            }
            throw new InvalidOperationException(string.Join(',', validationResult.Errors));
        }
    }
}