using MediatR;

namespace Tangled.Logic.Requests
{
    public class DeleteUserRequest : IRequest<RequestResult>
    {
        public int UserId { get; set; }
    }
}