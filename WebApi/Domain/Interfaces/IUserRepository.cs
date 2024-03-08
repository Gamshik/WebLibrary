using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> CreateUserAsync(IdentityUser<int> user, string password, CancellationToken cancellationToken = default);
        Task<IdentityUser<int>?> FindByEmailAsync(string email, CancellationToken cancellationToken = default);
        Task<bool> CheckPasswordAsync(IdentityUser<int> user, string password, CancellationToken cancellationToken = default);
    }
}
