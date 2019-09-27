using System.Linq;

namespace Data.Common
{
    public interface IDeletableEntityRepository<T> : IRepository<T>
        where T : class
    {
        IQueryable<T> AllWithDeleted();

        void ActualDelete(T entity);
    }
}