using System.Threading.Tasks;
using Application.Boundaries.UseCases.Authenticate;

namespace Application.Boundaries.UseCases.Authenticate
{
    public interface IAuthenticateUseCase
    {
        Task Execute(AuthenticationInput input);
    }
}
