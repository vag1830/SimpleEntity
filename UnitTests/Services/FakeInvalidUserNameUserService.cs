using System;
using System.Threading.Tasks;
using Application.Services;
using Domain.Entities;

namespace UnitTests.Services
{
    public class FakeInvalidUserNameUserService : IUserService
    {
        public async Task<SimpleEntityUser> FindByName(string name)
        {
            return await Task.FromResult<SimpleEntityUser>(null);
        }

        public Task<bool> CheckPassword(SimpleEntityUser user, string password)
        {
            throw new NotImplementedException();
        }
    }
}
