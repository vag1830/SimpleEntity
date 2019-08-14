using System;

namespace Core.Domain.Entities
{
    public class DefaultEntityFactory : IEntityFactory
    {
        public IEntity CreateSimpleEntity(Guid id, string title)
        {
            return new SimpleEntity(id, title);
        }
    }
}
