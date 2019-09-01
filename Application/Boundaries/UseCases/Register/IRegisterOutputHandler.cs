using Domain.Entities;

namespace Application.Boundaries.UseCases.Register
{
    public interface IRegisterOutputHandler
    {
        void Handle(SimpleEntityUser output);

        void Error(string message);
    }
}
