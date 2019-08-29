using System;
using System.Collections.Generic;
using Core.Application.Persistence;
using Core.Domain.Entities;

namespace Infrastucture.Repositories
{
    public class FakeSimpleEntityEmptyListRepository : ISimpleEntityRepository
    {
        public IList<SimpleEntity> Data = new List<SimpleEntity>();

        public IList<SimpleEntity> GetAll()
        {
            return Data;
        }

        public SimpleEntity GetById(Guid id)
        {
            return null;
        }
    }
}
