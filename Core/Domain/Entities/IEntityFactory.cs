using System;

namespace Core.Domain.Entities
{
    public interface IEntityFactory
    {
        IEntity CreateSimpleEntity(Guid id, string title);
    }
}
