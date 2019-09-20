using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Tangled.Logic.Models;
using Tangled.Logic.Repositories;
using Tangled.Logic.Requests;

namespace Tangled.Logic.Handlers
{
    public class GetAllUsersRequestHandler : IRequestHandler<GetAllUsersRequest, List<UserViewModel>>
    {
        private readonly IDbRepository dbRepository;

        public GetAllUsersRequestHandler(IDbRepository dbRepository)
        {
            this.dbRepository = dbRepository;
        }

        public Task<List<UserViewModel>> Handle(GetAllUsersRequest request, CancellationToken _)
            => this.dbRepository.GetAllUsersAsync();
    }
}