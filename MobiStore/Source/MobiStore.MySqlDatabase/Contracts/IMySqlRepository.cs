using System.Collections.Generic;
using System.Linq;

namespace MobiStore.MySqlDatabase.Contracts
{
    public interface IMySqlRepository<T> where T : class 
    {
        void Add(T Entity);

        void AddMany(IEnumerable<T> entities);

        IQueryable<T> All();

        void SaveChanges();
    }
}