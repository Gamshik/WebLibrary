using Domain.Classes.DTOs.UserDTOs;
using Domain.Classes.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUserService
    {
        Task<Jwt?> AuthorizationAsync(UserAuthorizeDto user, CancellationToken cancellationToken = default);
        Task<Result> RegistrationAsync(UserRegistrationDto user, CancellationToken cancellationToken = default);
    }
}
