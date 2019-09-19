using MediatR;
using Tangled.Logic.Models;

namespace Tangled.Logic.Requests
{
    public class UpdateUserRequest : IRequest<UserViewModel>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}