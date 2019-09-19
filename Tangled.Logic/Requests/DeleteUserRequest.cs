using MediatR;

namespace Tangled.Logic.Requests
{
    public class DeleteUserRequest : IRequest
    {
        public int UserId { get; set; }
    }
}