using Entities.DTOs.UserDTOs;
using FluentValidation;

namespace Validation.Config
{
    public class UserRegistrationValidator : AbstractValidator<UserRegistrationDto>
    {
        public UserRegistrationValidator()
        {
            RuleFor(u => u.UserName)
                .NotEmpty().WithMessage("User name is required!");

            RuleFor(u => u.Email)
                .NotEmpty().WithMessage("Email is required!")
                .EmailAddress().WithMessage("Email is not valid!");

            RuleFor(u => u.Password)
                .NotEmpty().WithMessage("Password is required!")
                .MinimumLength(10).WithMessage("Password can not be less than 10 symbols!");
        }
    }
}
