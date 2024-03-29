﻿using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Tangled.Logic.Repositories;
using Tangled.Logic.Requests;

namespace Tangled.Logic.Handlers
{
    public class DeleteUserRequestHandler : IRequestHandler<DeleteUserRequest,RequestResult>
    {
        private readonly IDbRepository dbRepository;

        public DeleteUserRequestHandler(IDbRepository dbRepository)
        {
            this.dbRepository = dbRepository;
        }

        public Task<RequestResult> Handle(
            DeleteUserRequest request, 
            CancellationToken cancellationToken)
        {
            this.dbRepository.DeleteUserByIdAsync(request);
            return Task.FromResult(new RequestResult());
        }
    }
}