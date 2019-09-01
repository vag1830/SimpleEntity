using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Boundaries.Persistence;
using Domain.Entities;

namespace UnitTests.Persistense
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
