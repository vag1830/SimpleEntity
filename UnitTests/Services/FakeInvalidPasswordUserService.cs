using System.Threading.Tasks;
using Application.Boundaries.Services;
using Domain.Entities;

namespace UnitTests.Services
{
    public class FakeInvalidPasswordUserService : IUserService
    {
        public async Task<SimpleEntityUser> FindByName(string name)
        {
            var user = new SimpleEntityUser();

            return await Task.FromResult(user);
        }

        public async Task<bool> CheckPassword(SimpleEntityUser user, string password)
        {
            return await Task.FromResult(false);
        }

        public Task<SimpleEntityUser> Create(SimpleEntityUser user, string password)
        {
            throw new System.NotImplementedException();
        }
    }
}
