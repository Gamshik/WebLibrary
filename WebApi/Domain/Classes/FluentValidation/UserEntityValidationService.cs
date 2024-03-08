using Domain.Classes.DTOs.UserDTOs;
using Domain.Classes.Entities;
using Domain.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Classes.FluentValidation
{
    public class UserEntityValidationService : IUserEntityValidationService
    {
        private readonly IValidator<UserRegistrationDto> _validator;
        public UserEntityValidationService(IValidator<UserRegistrationDto> validator)
        {
            _validator = validator;
        }
        public async Task<Result> UserRegistrationValidateAsync(UserRegistrationDto user, CancellationToken cancellationToken = default)
        {
            var result = await _validator.ValidateAsync(user);

            if (result.IsValid)
                return new Result { IsSuccess = true };

            return new Result { IsSuccess = false, StatusCode = 400, Message = $"{result.Errors.Select(e => e.PropertyName)} is not valid!" };
        }
    }
}
