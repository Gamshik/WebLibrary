using Entities;
using Entities.DTOs.UserDTOs;

namespace Contracts
{
    public interface IUserService
    {
        Task<Jwt?> AuthorizationAsync(UserAuthorizeDto user, CancellationToken cancellationToken = default);
        Task<Result> RegistrationAsync(UserRegistrationDto user, CancellationToken cancellationToken = default);
    }
}
