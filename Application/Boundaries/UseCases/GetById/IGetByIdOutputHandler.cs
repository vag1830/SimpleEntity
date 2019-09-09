using Domain.Entities;

namespace Application.Boundaries.UseCases.GetById
{
    public interface IGetByIdOutputHandler
    {
        void Handle(SimpleEntity output);

        void Error(string message);
    }
}
