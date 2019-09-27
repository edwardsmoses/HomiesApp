using Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Services.Repositories
{
    internal class GenericRepository<T> : IRepository<T>
        where T : class
    {
        public GenericRepository(DbContext dbContext)
        {
            Context = dbContext;
            EntitySet = dbContext.Set<T>();
        }

        protected DbContext Context { get; set; }

        public IDbSet<T> EntitySet { get; }

        public virtual IQueryable<T> All()
        {
            return EntitySet;
        }

        public virtual T GetById(object id)
        {
            return EntitySet.Find(id);
        }


        public virtual T Add(T entity)
        {
            return ChangeState(entity, EntityState.Added);
        }

        public virtual T Update(T entity)
        {
            return ChangeState(entity, EntityState.Modified);
        }

        public virtual void Delete(T entity)
        {
            ChangeState(entity, EntityState.Deleted);
        }

        public virtual T Delete(object id)
        {
            var entity = GetById(id);
            Delete(entity);
            return entity;
        }

        public int SaveChanges()
        {
            return Context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await Context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Context.Dispose();
        }

        private T ChangeState(T entity, EntityState state)
        {
            var entry = Context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                EntitySet.Attach(entity);
            }

            entry.State = state;
            return entity;
        }
    }
}