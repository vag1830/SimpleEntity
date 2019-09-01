using System;
using System.Threading.Tasks;
using Application.Boundaries.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Services
{
    public class UserService : IUserService
    {
        private UserManager<SimpleEntityUser> _userManager;

        public UserService(UserManager<SimpleEntityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<SimpleEntityUser> FindByName(string name)
        {
            return await _userManager.FindByNameAsync(name);
        }

        public async Task<bool> CheckPassword(SimpleEntityUser user, string password)
        {
            return await _userManager.CheckPasswordAsync(user, password);
        }

        public async Task<SimpleEntityUser> Create(SimpleEntityUser user, string password)
        {
            var result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                return await FindByName(user.UserName);
            }

            throw new Exception(result.ToString());
        }
    }
}
