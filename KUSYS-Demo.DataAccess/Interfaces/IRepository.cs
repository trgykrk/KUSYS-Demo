using System;
using System.Linq.Expressions;

namespace KUSYS_Demo.DataAccess.Interfaces
{
    public interface IRepository<T> where T: class,new()
    {
        Task<List<T>> GetDataAll();
        Task<T?> GetById(object id);
        Task<T?>GetByFilter(Expression<Func<T,bool>> filter,bool asNoTracking=false);
        Task Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
