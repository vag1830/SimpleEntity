using System;
using System.Collections.Generic;
using System.Linq;
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
            var items = await _context.SimpleEntities
                .ToListAsync();

            return items
                .Select(CreateSimpleEntity)
                .ToList();
        }

        public async Task<SimpleEntity> GetById(Guid id)
        {
            var item = await _context.SimpleEntities
                .FirstOrDefaultAsync(simpleEntity => simpleEntity.Id == id);

            return CreateSimpleEntity(item);
        }

        private SimpleEntity CreateSimpleEntity(SimpleEntityDao dao)
        {
            return new SimpleEntity(dao.Id, dao.Title);
        }
    }
}
