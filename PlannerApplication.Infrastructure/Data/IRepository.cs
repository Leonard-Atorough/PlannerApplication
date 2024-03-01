using PlannerApplication.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PlannerApplication.Infrastructure.Data
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        void Insert(TEntity entity);
        bool Update(TEntity entity);
        bool Delete(TEntity entity);
        IQueryable<TEntity> SearchFor(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> GetAll();
        TEntity GetById(int id);
    }
}
