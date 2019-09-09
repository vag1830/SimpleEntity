using System;
using Core.Domain.Entities;

namespace Domain.Entities
{
    public class SimpleEntity : IEntity
    {
        public Guid Id { get; }

        public string Title { get; }

        public SimpleEntity(Guid id, string title)
        {
            if (id == null)
            {
                throw new Exception("Id should not be null");
            }

            Id = id;
            Title = title;
        }
    }
}
