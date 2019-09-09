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
        private readonly IEntityFactory _entityFactory;

        public InMemorySimpleEntityRepository(SimpleEntityContext context, IEntityFactory entityFactory)
        {
            _context = context;
            _entityFactory = entityFactory;

            _context.Database.EnsureCreated();
        }

        public async Task<IList<SimpleEntity>> GetAll()
        {
            var items = await _context.SimpleEntities
                .ToListAsync();

            return items
                .Select(item => _entityFactory.NewSimpleEntity(item.Id, item.Title))
                .ToList();
        }

        public async Task<SimpleEntity> GetById(Guid id)
        {
            var item = await _context.SimpleEntities
                .FirstOrDefaultAsync(simpleEntity => simpleEntity.Id == id);

            return _entityFactory.NewSimpleEntity(item.Id, item.Title);
        }
    }
}
