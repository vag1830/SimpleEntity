using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Domain.Entities;

namespace Core.Application.Boundaries.UseCases.GetAll
{
    public interface IGetAllOutputHandler
    {
        Task Handle(IList<SimpleEntity> output);

        Task Error(string message);
    }
}
