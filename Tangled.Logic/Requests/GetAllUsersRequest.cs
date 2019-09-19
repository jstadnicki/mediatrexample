using System.Collections.Generic;
using MediatR;
using Tangled.Logic.Models;

namespace Tangled.Logic.Requests
{
    public class GetAllUsersRequest : IRequest<List<UserViewModel>>
    {
    }
}