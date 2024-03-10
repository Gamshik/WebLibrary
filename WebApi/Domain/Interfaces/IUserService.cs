using Domain.Classes.DTOs.UserDTOs;
using Domain.Classes.Entities;

namespace Domain.Interfaces
{
    public interface IUserService
    {
        Task<Jwt?> AuthorizationAsync(UserAuthorizeDto user, CancellationToken cancellationToken = default);
        Task<Result> RegistrationAsync(UserRegistrationDto user, CancellationToken cancellationToken = default);
    }
}
