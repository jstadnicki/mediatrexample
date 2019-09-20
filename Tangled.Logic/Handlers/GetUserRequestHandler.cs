using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Tangled.Logic.Models;
using Tangled.Logic.Repositories;
using Tangled.Logic.Requests;

namespace Tangled.Logic.Handlers
{
    public class GetUserRequestHandler : IRequestHandler<GetUserRequest, UserViewModel>
    {
        private readonly IDbRepository dbRepository;

        public GetUserRequestHandler(IDbRepository dbRepository)
        {
            this.dbRepository = dbRepository;
        }

        public async Task<UserViewModel> Handle(
            GetUserRequest request,
            CancellationToken cancellationToken)
        {
            var vmUser = await this.dbRepository.GetByIdAsync(request);
            return vmUser;
        }
    }
}