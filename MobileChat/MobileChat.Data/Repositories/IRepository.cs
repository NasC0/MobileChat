using System.Collections.Generic;

namespace MobileChat.Data.Repositories
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> All();

        void Add(T entry);

        T Find(object id);

        void Update(T entry);

        T Remove(T entry);

        int SaveChanges();
    }
}
