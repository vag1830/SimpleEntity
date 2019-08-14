using System.Collections.Generic;
using Core.Domain.Entities;

namespace Core.Application.Boundaries.UseCases.GetAll
{
    public interface IGetAllOutputHandler
    {
        void Handle(IList<SimpleEntity> output);

        void Error();
    }
}
