using System.Threading.Tasks;
using Core.Domain.Entities;

namespace Core.Application.Boundaries.UseCases.Authenticate
{
    public interface IAuthenticateOutputHandler
    {
        Task Handle(SimpleEntityUser output);

        Task Error(string message);
    }
}
