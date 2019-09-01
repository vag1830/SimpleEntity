using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistense
{
    public class SimpleEntityUserContext : IdentityDbContext<SimpleEntityUser>
    {
        public SimpleEntityUserContext(DbContextOptions<SimpleEntityUserContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
