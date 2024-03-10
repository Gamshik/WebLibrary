using Domain.Classes.DTOs.UserDTOs;
using Domain.Classes.Entities;
using Domain.Classes.FluentValidation.Extensions;
using Domain.Interfaces;
using FluentValidation;

namespace Domain.Classes.FluentValidation
{
    public class UserEntitiesValidationService : IUserEntitiesValidationService
    {
        private readonly IValidator<UserRegistrationDto> _validator;
        public UserEntitiesValidationService(IValidator<UserRegistrationDto> validator)
        {
            _validator = validator;
        }
        public async Task<Result> UserRegistrationValidateAsync(UserRegistrationDto user, CancellationToken cancellationToken = default)
        {
            var result = await _validator.ValidateAsync(user);

            if (result.IsValid)
                return new Result { IsSuccess = true };

            return new Result { IsSuccess = false, StatusCode = 400, Message = result.ErrorsToString() };
        }
    }
}
