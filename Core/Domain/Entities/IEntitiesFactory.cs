using System;

namespace Core.Domain.Entities
{
    public interface IEntitiesFactory
    {
        IEntity CreateSimpleEntity(Guid id, string title);
    }
}
