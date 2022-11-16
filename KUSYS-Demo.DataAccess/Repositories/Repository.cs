using KUSYS_Demo.DataAccess.Contexts;
using KUSYS_Demo.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KUSYS_Demo.DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        private readonly KUSYSDemoContext _context;

        public Repository(KUSYSDemoContext context)
        {
            _context = context;
        }

        public async Task Create(T entity)
        {
           await _context.Set<T>().AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public async Task<T?> GetByFilter(Expression<Func<T, bool>> filter, bool asNoTracking = false)
        {
            return asNoTracking? await _context.Set<T>().SingleOrDefaultAsync(filter) : await _context.Set<T>().AsNoTracking().SingleOrDefaultAsync(filter);
        }

        public async Task<T?> GetById(object id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> GetDataAll()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}
