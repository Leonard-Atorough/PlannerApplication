using PlannerApplication.Core.Interfaces;
using System.Linq.Expressions;

namespace PlannerApplication.Infrastructure.Data
{
    public interface IRepository<T> where T : class, IAggregateRoot, IEntity
    {
        void Insert(T entity);
        bool Update(T entity);
        bool Delete(T entity);
        IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetAll();
        T? GetById(int id);
    }
}
