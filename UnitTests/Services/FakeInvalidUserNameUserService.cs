using System;
using System.Threading.Tasks;
using Application.Boundaries.Services;
using Domain.Entities;

namespace UnitTests.Services
{
    public class FakeInvalidUserNameUserService : IUserService
    {
        public SimpleEntityUser User = new SimpleEntityUser();
        public string ErrorMessage = "Error Message";

        public async Task<SimpleEntityUser> FindByName(string name)
        {
            return await Task.FromResult<SimpleEntityUser>(null);
        }

        public Task<bool> CheckPassword(SimpleEntityUser user, string password)
        {
            throw new NotImplementedException();
        }

        public Task<SimpleEntityUser> Create(SimpleEntityUser user, string password)
        {
            throw new Exception(ErrorMessage);
        }
    }
}
