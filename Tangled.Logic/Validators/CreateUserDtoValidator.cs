using FluentValidation;
using Tangled.Logic.DTOs;

namespace Tangled.Logic.Validators
{
    public class CreateUserDtoValidator : AbstractValidator<CreateUserDto>
    {
        public CreateUserDtoValidator()
        {
        }
    }
}