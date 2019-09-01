using System.Threading.Tasks;
using Application.Services;
using Domain.Entities;

namespace UnitTests.Services
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
    }
}
