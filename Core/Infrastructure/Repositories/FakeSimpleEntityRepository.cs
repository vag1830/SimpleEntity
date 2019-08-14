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

        public IList<SimpleEntity> GetAll()
        {
            return Data;
        }
    }
}
