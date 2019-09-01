using System;
using Core.Domain.Entities;

namespace Domain.Entities
{
    public class SimpleEntity : IEntity
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public SimpleEntity()
        {

        }

        public SimpleEntity(Guid id, string title)
        {
            Id = id;
            Title = title;
        }
    }
}
