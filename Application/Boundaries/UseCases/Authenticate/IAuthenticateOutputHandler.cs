using Domain.Entities;

namespace Application.Boundaries.UseCases.Authenticate
{
    public interface IAuthenticateOutputHandler
    {
        void Handle(SimpleEntityUser output);

        void Error(string message);
    }
}
