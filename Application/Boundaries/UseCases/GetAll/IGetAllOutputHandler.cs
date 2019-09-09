using System.Collections.Generic;
using Domain.Entities;

namespace Application.Boundaries.UseCases.GetAll
{
    public interface IGetAllOutputHandler
    {
        void Handle(IList<SimpleEntity> output);

        void Error(string message);
    }
}
