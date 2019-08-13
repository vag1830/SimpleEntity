using System;

namespace Core.Domain.Entities
{
    public class DefaultEntitiesFactory : IEntitiesFactory
    {
        public IEntity CreateSimpleEntity(Guid id, string title)
        {
            return new SimpleEntity(id, title);
        }
    }
}
