using System;

namespace Core.Domain.Entities
{
    public interface IEntity
    {
        Guid Id { get; }
    }
}
