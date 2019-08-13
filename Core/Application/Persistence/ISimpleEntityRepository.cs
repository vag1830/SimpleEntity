using System.Collections.Generic;
using Core.Domain.Entities;

namespace Core.Application.Persistence
{
    public interface ISimpleEntityRepository
    {
        IList<SimpleEntity> GetAll();
    }
}
