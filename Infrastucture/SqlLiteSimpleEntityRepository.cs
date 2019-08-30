using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Application.Persistence;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastucture
{
    public class SqlLiteSimpleEntityRepository : ISimpleEntityRepository
    {
        private readonly SimpleEntityContext _context;

        public SqlLiteSimpleEntityRepository(SimpleEntityContext context)
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
