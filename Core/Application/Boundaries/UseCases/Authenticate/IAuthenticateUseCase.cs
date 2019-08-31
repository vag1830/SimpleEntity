using System.Threading.Tasks;

namespace Core.Application.Boundaries.UseCases.Authenticate
{
    public interface IAuthenticateUseCase
    {
        Task Execute(AuthenticationInput input);
    }
}
