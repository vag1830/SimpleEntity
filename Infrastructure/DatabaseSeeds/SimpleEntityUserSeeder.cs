using System;
using System.Linq;
using Core.Domain.Entities;
using Infrastructure.Persistense;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.DatabaseSeeds
{
    public class SimpleEntityUserSeeder
    {
        private readonly SimpleEntityContext _context;
        private readonly UserManager<SimpleEntityUser> _userManager;

        public SimpleEntityUserSeeder(SimpleEntityContext context, UserManager<SimpleEntityUser> userManager, IServiceProvider serviceProvider)
        {
            _context = context;
            _userManager = userManager;
        }

        public void Seed()
        {
            _context.Database.EnsureCreated();

            if (!_context.Users.Any())
            {
                var user = new SimpleEntityUser
                {
                    Email = "a@b.com",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = "username"
                };

                _userManager.CreateAsync(user, "P@ssword!23")
                    .GetAwaiter()
                    .GetResult();
            }
        }
    }
}
