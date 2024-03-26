using MongoDB.Bson;
using PlannerApplication.Core.Interfaces;
using System.Linq.Expressions;

namespace PlannerApplication.Infrastructure.Data
{
    public interface IRepository<T> where T : class, IAggregateRoot, IEntity
    {
        T? Insert(T entity);
        Task<T> InsertAsync(T entity);
        bool Update(T entity);
        Task<bool> UpdateAsync(T entity);
        bool Delete(T entity);
        Task<bool> DeleteAsync(T entity);
        IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate);
        Task<IQueryable<T>> SearchForAsync(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetAll();
        Task<IQueryable<T>> GetAllAsync();
        T? GetById(ObjectId id);
        Task<T> GetByIdAsync(ObjectId id);
    }
}
