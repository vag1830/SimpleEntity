using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Boundaries.UseCases.GetAll
{
    public interface IGetAllOutputHandler
    {
        Task Handle(IList<SimpleEntity> output);

        Task Error(string message);
    }
}
