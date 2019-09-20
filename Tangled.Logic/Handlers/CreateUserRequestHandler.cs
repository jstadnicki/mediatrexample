using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Tangled.Logic.Repositories;
using Tangled.Logic.Requests;

namespace Tangled.Logic.Handlers
{
    public class CreateUserRequestHandler : IRequestHandler<CreateUserRequest, RequestResult>
    {
        private readonly IDbRepository dbRepository;

        public CreateUserRequestHandler(IDbRepository dbRepository)
        {
            this.dbRepository = dbRepository;
        }

        public async Task<RequestResult> Handle(
            CreateUserRequest request,
            CancellationToken cancellationToken)
        {
            await this.dbRepository.CreateUserAsync(request);
            return new RequestResult();
        }
    }
}