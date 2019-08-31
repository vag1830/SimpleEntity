using System.Threading.Tasks;
using Core.Domain.Entities;

namespace Core.Application.Services
{
    public interface IUserService
    {
        Task<SimpleEntityUser> FindByName(string name);

        Task<bool> CheckPassword(SimpleEntityUser user, string password);
    }
}
