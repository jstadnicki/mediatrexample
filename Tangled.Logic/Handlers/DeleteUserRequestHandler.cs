﻿using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Tangled.Database.Repository;
using Tangled.Logic.Requests;

namespace Tangled.Logic.Handlers
{
    public class DeleteUserRequestHandler : IRequestHandler<DeleteUserRequest>
    {
        private readonly IDbRepository dbRepository;

        public DeleteUserRequestHandler(IDbRepository dbRepository)
        {
            this.dbRepository = dbRepository;
        }

        public Task<Unit> Handle(
            DeleteUserRequest request, 
            CancellationToken cancellationToken)
        {
            this.dbRepository.DeleteUserByIdAsync(request.UserId);
            return Task.FromResult(new Unit());
        }
    }
}