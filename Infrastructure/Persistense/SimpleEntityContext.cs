using System;
using System.Collections.Generic;
using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistense
{
    public class SimpleEntityContext : IdentityDbContext<SimpleEntityUser>
    {
        public DbSet<SimpleEntityDao> SimpleEntities { get; set; }

        public SimpleEntityContext(DbContextOptions<SimpleEntityContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<SimpleEntityDao>()
                .HasData(Data);
        }

        private readonly IList<SimpleEntityDao> Data = new List<SimpleEntityDao>
        {
            new SimpleEntityDao(Guid.NewGuid(), "one"),
            new SimpleEntityDao(Guid.NewGuid(), "two"),
            new SimpleEntityDao(Guid.NewGuid(), "three")
        };
    }
}
