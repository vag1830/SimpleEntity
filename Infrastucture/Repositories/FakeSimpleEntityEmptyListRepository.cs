using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Application.Persistence;
using Core.Domain.Entities;

namespace Infrastucture.Repositories
{
    public class FakeSimpleEntityEmptyListRepository : ISimpleEntityRepository
    {
        public IList<SimpleEntity> Data = new List<SimpleEntity>();

        public Task<IList<SimpleEntity>> GetAll()
        {
            return Task.FromResult(Data);
        }

        public Task<SimpleEntity> GetById(Guid id)
        {
            return Task.FromResult(null as SimpleEntity);
        }
    }
}
