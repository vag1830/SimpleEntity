using System.Threading.Tasks;
using Application.Boundaries.UseCases.Authenticate;
using Domain.Entities;

namespace UnitTests.UseCases.Authenticate
{
    public class FakeAuthenticateOutputHandler : IAuthenticateOutputHandler
    {
        public SimpleEntityUser ViewModel { get; private set; }

        public string ErrorMessage { get; private set; }

        public async Task Handle(SimpleEntityUser output)
        {
            ViewModel = output;

            await Task.CompletedTask;
        }

        public async Task Error(string message)
        {
            ErrorMessage = message;

            await Task.CompletedTask;
        }
    }
}