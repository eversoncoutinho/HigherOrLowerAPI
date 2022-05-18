using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IRepository<T>
        {
            IQueryable<T> Get();
            T GetById(Expression<Func<T, bool>> predicate);
            void Add(T entity);
        Task AddAsync(T entity);
        void Update(T entity);
            void Delete(T entity);

        }
}
