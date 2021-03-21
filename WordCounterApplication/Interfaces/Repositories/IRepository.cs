using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace WordCounterApplication.Interfaces.Repositories
{
    /// <summary>
    /// IRepository is interface for generic repositories that acess entities.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    interface IRepository<T> where T : class
    {
        T GetById(int id);

        IEnumerable<T> GetAll();

        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);

        void Add(T entity);

        void AddRange(IEnumerable<T> entities);

        void Remove(T entity);

        void RemoveRange(IEnumerable<T> entities);
    }
}
