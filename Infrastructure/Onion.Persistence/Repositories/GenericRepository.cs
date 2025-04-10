using Microsoft.EntityFrameworkCore;
using Onion.Application.Interfaces;
using Onion.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Persistence.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _context;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsycn(T entity)
        {
            await _context.AddAsync(entity);
        }
           

        public async Task DeleteAsycn(Guid id)
        {
            var entity = await GetByIdAsycn(id);
            _context.Remove(entity);
           
        }

        public async Task<List<T>> GetAllAsycn()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T> GetByIdAsycn(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public  void Update(T entity)
        {
            _context.Update(entity);
        }
    }
}
