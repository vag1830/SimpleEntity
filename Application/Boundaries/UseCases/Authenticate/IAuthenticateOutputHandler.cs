using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Boundaries.UseCases.Authenticate
{
    public interface IAuthenticateOutputHandler
    {
        Task Handle(SimpleEntityUser output);

        Task Error(string message);
    }
}
