using System.Threading.Tasks;

namespace Application.Boundaries.UseCases.Register
{
    public interface IRegisterUseCase
    {
        Task Execute(RegistrationInput input);
    }
}
