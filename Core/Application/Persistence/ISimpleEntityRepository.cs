using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Domain.Entities;

namespace Core.Application.Persistence
{
    public interface ISimpleEntityRepository
    {
        Task<IList<SimpleEntity>> GetAll();

        Task<SimpleEntity> GetById(Guid id);
    }
}
