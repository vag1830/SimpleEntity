using System.Threading.Tasks;
using Core.Application.Services;
using Core.Domain.Entities;
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
    }
}
