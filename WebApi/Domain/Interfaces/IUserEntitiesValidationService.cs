using Domain.Classes.DTOs.UserDTOs;
using Domain.Classes.Entities;

namespace Domain.Interfaces
{
    public interface IUserEntitiesValidationService
    {
        Task<Result> UserRegistrationValidateAsync(UserRegistrationDto user, CancellationToken cancellationToken = default);
    }
}
