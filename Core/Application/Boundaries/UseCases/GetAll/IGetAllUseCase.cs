using System.Collections.Generic;
using Core.Domain.Entities;

namespace Core.Application.Boundaries.UseCases.GetAllUseCase
{
    interface IGetAllUseCase
    {
        IList<SimpleEntity> Execure();
    }
}
