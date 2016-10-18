using System;
using System.Linq;
using System.Linq.Expressions;

namespace MobiStore.Data.Contracts
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> All();

        IQueryable<T> Find(Expression<Func<T, bool>> conditions);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        void Detach(T entity);
    }
}