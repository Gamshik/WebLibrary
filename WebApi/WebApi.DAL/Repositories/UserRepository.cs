﻿using Contracts;
using Microsoft.AspNetCore.Identity;

namespace WebApi.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<IdentityUser<int>> _userManager;
        public UserRepository(UserManager<IdentityUser<int>> userManager)
        {
            _userManager = userManager;
        }

        public async Task<bool> CheckPasswordAsync(IdentityUser<int> user, string password, CancellationToken cancellationToken = default)
        {
            return await _userManager.CheckPasswordAsync(user, password);
        }

        public async Task<bool> CreateUserAsync(IdentityUser<int> user, string password, CancellationToken cancellationToken = default)
        {
            var result = await _userManager.CreateAsync(user, password);

            return result.Succeeded;
        }

        public async Task<IdentityUser<int>?> FindByEmailAsync(string email, CancellationToken cancellationToken = default)
        {
            return await _userManager.FindByEmailAsync(email);
        }
    }
}
