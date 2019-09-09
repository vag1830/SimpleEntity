using System;

namespace Infrastructure.Persistense
{
    public class SimpleEntityDao
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public SimpleEntityDao()
        {

        }

        public SimpleEntityDao(Guid id, string title)
        {
            Id = id;
            Title = title;
        }
    }
}
