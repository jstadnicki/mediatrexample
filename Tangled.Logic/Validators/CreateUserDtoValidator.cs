using FluentValidation;
using Tangled.Logic.Requests;

namespace Tangled.Logic.Validators
{
    public class CreateUserDtoValidator : AbstractValidator<CreateUserRequest>
    {
        public CreateUserDtoValidator()
        {
        }
    }
}