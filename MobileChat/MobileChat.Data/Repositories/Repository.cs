using System.Collections.Generic;
using System.Data.Entity;

namespace MobileChat.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private IMobileChatDbContext dbContext;

        public Repository()
            : this(new MobileChatDbContext())
        {
        }

        public Repository(IMobileChatDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<T> All()
        {
            return this.dbContext.Set<T>();
        }

        public void Add(T entry)
        {
            this.ChangeState(entry, EntityState.Added);
        }

        public T Find(object id)
        {
            return this.dbContext.Set<T>().Find(id);
        }

        public void Update(T entry)
        {
            this.ChangeState(entry, EntityState.Modified);
        }

        public T Remove(T entry)
        {
            this.ChangeState(entry, EntityState.Deleted);
            return entry;
        }

        public int SaveChanges()
        {
            return this.dbContext.SaveChanges();
        }

        private void ChangeState(T entity, EntityState state)
        {
            var entry = this.dbContext.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.dbContext.Set<T>().Attach(entity);
            }

            entry.State = state;
        }
    }
}
