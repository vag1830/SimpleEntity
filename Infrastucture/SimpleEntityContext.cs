using System;
using System.Collections.Generic;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastucture
{
    public class SimpleEntityContext : DbContext
    {
        public DbSet<SimpleEntity> SimpleEntities { get; set; }

        public SimpleEntityContext(DbContextOptions<SimpleEntityContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<SimpleEntity>()
                .HasData(Data);
        }

        private readonly IList<SimpleEntity> Data = new List<SimpleEntity>
        {
            new SimpleEntity(Guid.NewGuid(), "one"),
            new SimpleEntity(Guid.NewGuid(), "two"),
            new SimpleEntity(Guid.NewGuid(), "three")
        };
    }
}
