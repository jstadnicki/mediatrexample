using FluentValidation;
using Tangled.Api.DTOs;

namespace Tangled.Api.Validators
{
    public class CreateUserDtoValidator : AbstractValidator<CreateUserDto>
    {
        public CreateUserDtoValidator()
        {
        }
    }
}