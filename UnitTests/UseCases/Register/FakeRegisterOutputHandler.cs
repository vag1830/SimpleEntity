using Application.Boundaries.UseCases.Register;
using Domain.Entities;

namespace UnitTests.UseCases.Authenticate
{
    public class FakeRegisterOutputHandler : IRegisterOutputHandler
    {
        public SimpleEntityUser ViewModel { get; private set; }

        public string ErrorMessage { get; private set; }

        public void Handle(SimpleEntityUser output)
        {
            ViewModel = output;
        }

        public void Error(string message)
        {
            ErrorMessage = message;
        }
    }
}