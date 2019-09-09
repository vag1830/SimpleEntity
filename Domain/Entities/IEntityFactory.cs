using System;

namespace Domain.Entities
{
    public interface IEntityFactory
    {
        SimpleEntity NewSimpleEntity(Guid id, string title);
    }
}
