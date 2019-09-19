using MediatR;

namespace Tangled.Logic.Requests
{
    public class CreateUserRequest : IRequest
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}