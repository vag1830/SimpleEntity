﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Boundaries.Persistence;
using Domain.Entities;

namespace UnitTests.Persistense
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

        public Task<IList<SimpleEntity>> GetAll()
        {
            return Task.FromResult(Data);
        }

        public Task<SimpleEntity> GetById(Guid id)
        {
            Item = new SimpleEntity(id, "One");

            return Task.FromResult(Item);
        }
    }
}
