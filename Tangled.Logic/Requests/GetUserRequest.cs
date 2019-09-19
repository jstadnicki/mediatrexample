using MediatR;
using Tangled.Logic.Models;

namespace Tangled.Logic.Requests
{
    public class GetUserRequest : IRequest<UserViewModel>
    {
        public int UserId { get; set; }
    }
}