using System;
using Core.Domain.Entities;

namespace Domain.Entities
{
    public interface IEntityFactory
    {
        IEntity CreateSimpleEntity(Guid id, string title);
    }
}
