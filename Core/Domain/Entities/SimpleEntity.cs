using System;

namespace Core.Domain.Entities
{
    public class SimpleEntity : IEntity
    {
        public Guid Id { get; }

        public string Title { get; }

        public SimpleEntity(Guid id, string title)
        {
            Id = id;
            Title = title;
        }
    }
}
