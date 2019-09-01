using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Boundaries.UseCases.GetById
{
    public interface IGetByIdOutputHandler
    {
        Task Handle(SimpleEntity output);

        Task Error(string message);
    }
}
