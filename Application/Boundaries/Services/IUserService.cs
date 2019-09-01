using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Boundaries.Services
{
    public interface IUserService
    {
        Task<SimpleEntityUser> FindByName(string name);

        Task<bool> CheckPassword(SimpleEntityUser user, string password);

        Task<SimpleEntityUser> Create(SimpleEntityUser user, string password);
    }
}
