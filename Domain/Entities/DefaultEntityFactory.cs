using System;

namespace Domain.Entities
{
    public class DefaultEntityFactory : IEntityFactory
    {
        public SimpleEntity NewSimpleEntity(Guid id, string title)
        {
            return new SimpleEntity(id, title);
        }
    }
}
