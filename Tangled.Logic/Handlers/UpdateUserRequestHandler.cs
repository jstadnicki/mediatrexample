using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Tangled.Logic.Models;
using Tangled.Logic.Repositories;
using Tangled.Logic.Requests;

namespace Tangled.Logic.Handlers
{
    public class UpdateUserRequestHandler : IRequestHandler<UpdateUserRequest, UserViewModel>
    {
        private readonly IDbRepository dbRepository;

        public UpdateUserRequestHandler(IDbRepository dbRepository)
        {
            this.dbRepository = dbRepository;
        }

        public async Task<UserViewModel> Handle(
            UpdateUserRequest request,
            CancellationToken cancellationToken)
        {
            var updatedUser = await this.dbRepository.UpdateUserAsync(request);
            return updatedUser;
        }
    }
}