using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Tangled.Logic.Models;
using Tangled.Logic.Repositories;
using Tangled.Logic.Requests;

namespace Tangled.Logic.Handlers
{
    public class GetAllUsersRequestHandler : IRequestHandler<GetAllUsersRequest,List<UserViewModel>>
    {
        private readonly IDbRepository dbRepository;
        private readonly IMapper mapper;

        public GetAllUsersRequestHandler(
            IDbRepository dbRepository, 
            IMapper mapper)
        {
            this.dbRepository = dbRepository;
            this.mapper = mapper;
        }

        public async Task<List<UserViewModel>> Handle(
            GetAllUsersRequest request, 
            CancellationToken cancellationToken)
            => await this.dbRepository.GetAllUsersAsync();
    }
}