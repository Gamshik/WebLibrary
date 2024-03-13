using Entities;
using Entities.DTOs.UserDTOs;

namespace Contracts
{
    public interface IUserEntitiesValidationService
    {
        Task<Result> UserRegistrationValidateAsync(UserRegistrationDto user, CancellationToken cancellationToken = default);
    }
}
