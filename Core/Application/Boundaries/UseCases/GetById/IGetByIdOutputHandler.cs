using System.Threading.Tasks;
using Core.Domain.Entities;

namespace Core.Application.Boundaries.UseCases.GetById
{
    public interface IGetByIdOutputHandler
    {
        Task Handle(SimpleEntity output);

        Task Error(string message);
    }
}
