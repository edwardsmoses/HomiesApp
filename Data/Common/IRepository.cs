using System;
using System.Linq;

namespace Data.Common
{
    public interface IRepository<T> : IDisposable
        where T : class
    {
        IQueryable<T> All();

        T GetById(object id);

        T Add(T entity);

        T Update(T entity);

        T Delete(object id);

        void Delete(T entity);

        int SaveChanges();
    }
}