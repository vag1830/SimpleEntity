using System;
using System.Collections.Generic;
using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistense
{
    public class SimpleEntityContext : IdentityDbContext<SimpleEntityUser>
    {
        public DbSet<SimpleEntity> SimpleEntities { get; set; }

        public SimpleEntityContext(DbContextOptions<SimpleEntityContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

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
