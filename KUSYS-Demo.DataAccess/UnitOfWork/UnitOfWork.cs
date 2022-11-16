using KUSYS_Demo.DataAccess.Contexts;
using KUSYS_Demo.DataAccess.Interfaces;
using KUSYS_Demo.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUSYS_Demo.DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly KUSYSDemoContext _context;

        public UnitOfWork(KUSYSDemoContext context)
        {
            _context = context;
        }

        public IRepository<T> GetRepository<T>() where T : class, new()
        {
            return new Repository<T>(_context);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
