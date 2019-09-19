using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Tangled.Database.Database;
using Tangled.Database.Repository;
using Tangled.Logic.Models;
using Tangled.Logic.Requests;

namespace Tangled.Logic.Handlers
{
    public class GetUserRequestHandler : IRequestHandler<GetUserRequest, UserViewModel>
    {
        private readonly IMapper mapper;
        private readonly IDbRepository dbRepository;

        public GetUserRequestHandler(
            IMapper mapper, 
            IDbRepository dbRepository)
        {
            this.mapper = mapper;
            this.dbRepository = dbRepository;
        }

        public async Task<UserViewModel> Handle(
            GetUserRequest request,
            CancellationToken cancellationToken)
        {
            var dbUser = await this.dbRepository.GetByIdAsync(request.UserId);
            var vmUser = this.mapper.Map<User, UserViewModel>(dbUser);
            return vmUser;
        }
    }
}