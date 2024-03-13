using Microsoft.AspNetCore.Identity;

namespace Contracts
{
    public interface IUserRepository
    {
        Task<bool> CreateUserAsync(IdentityUser<int> user, string password, CancellationToken cancellationToken = default);
        Task<IdentityUser<int>?> FindByEmailAsync(string email, CancellationToken cancellationToken = default);
        Task<bool> CheckPasswordAsync(IdentityUser<int> user, string password, CancellationToken cancellationToken = default);
    }
}
