using System.Collections.Generic;
using System.Linq;

using MobiStore.MySqlDatabase.Contracts;

namespace MobiStore.MySqlDatabase.Repositories
{
    public class MySqlRepository<T> : IMySqlRepository<T> where T : class
    {
        private readonly MySqlContext context;

        public MySqlRepository(MySqlContext context)
        {
            this.context = context;
        }

        public void Add(T entity)
        {
            this.context.Add(entity);
        }

        public void AddMany(IEnumerable<T> entities)
        {
            this.context.Add(entities);
        }

        public IQueryable<T> All()
        {
            return this.context.GetAll<T>();
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }
    }
}