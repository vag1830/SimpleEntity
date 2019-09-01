using System.Threading.Tasks;
using Application.Boundaries.Services;
using Domain.Entities;

namespace Infrastructure.Services
{
    public class FakeUserService : IUserService
    {
        public SimpleEntityUser User = new SimpleEntityUser();

        public async Task<SimpleEntityUser> FindByName(string name)
        {
            return await Task.FromResult(User);
        }

        public async Task<bool> CheckPassword(SimpleEntityUser user, string password)
        {
            return await Task.FromResult(true);
        }

        public async Task<SimpleEntityUser> Create(SimpleEntityUser user, string password)
        {
            User = user;

            return await Task.FromResult(User);
        }
    }
}
