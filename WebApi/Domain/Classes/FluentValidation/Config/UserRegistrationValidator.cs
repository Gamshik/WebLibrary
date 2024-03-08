using Domain.Classes.DTOs.UserDTOs;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Classes.FluentValidation.Config
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
                .MinimumLength(10).WithMessage("Password will not be less than 10 symbols!");
        }
    }
}
