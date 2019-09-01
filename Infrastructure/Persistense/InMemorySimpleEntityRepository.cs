using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Boundaries.Persistence;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistense
{
    public class InMemorySimpleEntityRepository : ISimpleEntityRepository
    {
        private readonly SimpleEntityContext _context;

        public InMemorySimpleEntityRepository(SimpleEntityContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        public async Task<IList<SimpleEntity>> GetAll()
        {
            var crap = await _context.SimpleEntities
                .ToListAsync();

            return crap;
        }

        public async Task<SimpleEntity> GetById(Guid id)
        {
            return await _context.SimpleEntities
                .FirstOrDefaultAsync(simpleEntity => simpleEntity.Id == id);
        }
    }
}
