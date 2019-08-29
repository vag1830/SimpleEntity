using System;
using System.Collections.Generic;
using Core.Application.Persistence;
using Core.Domain.Entities;

namespace Core.Infrastructure.Repositories
{
    public class FakeSimpleEntityRepository : ISimpleEntityRepository
    {
        public IList<SimpleEntity> Data = new List<SimpleEntity>
        {
            new SimpleEntity(Guid.NewGuid(), "One"),
            new SimpleEntity(Guid.NewGuid(), "Two"),
            new SimpleEntity(Guid.NewGuid(), "Three"),
        };

        public SimpleEntity Item;

        public IList<SimpleEntity> GetAll()
        {
            return Data;
        }

        public SimpleEntity GetById(Guid id)
        {
            Item = new SimpleEntity(id, "One");

            return Item;
        }
    }
}
