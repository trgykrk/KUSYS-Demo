using KUSYS_Demo.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUSYS_Demo.DataAccess.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRepository<T> GetRepository<T>() where T : class, new();

        Task SaveChanges();
    }
}
