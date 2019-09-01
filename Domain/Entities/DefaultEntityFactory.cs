using System;
using Core.Domain.Entities;

namespace Domain.Entities
{
    public class DefaultEntityFactory : IEntityFactory
    {
        public IEntity CreateSimpleEntity(Guid id, string title)
        {
            return new SimpleEntity(id, title);
        }
    }
}
