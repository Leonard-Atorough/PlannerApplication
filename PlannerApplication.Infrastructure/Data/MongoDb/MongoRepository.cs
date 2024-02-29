using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PlannerApplication.Core.Entities;
using PlannerApplication.Infrastructure.Configuration;
using System.Linq.Expressions;

namespace PlannerApplication.Infrastructure.Data.MongoDb
{
    public class MongoRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly IDatabaseFactory _mongoDatabaseFactory;

        private readonly IMongoCollection<TEntity> _collection;

        public MongoRepository(IOptions<MongoDbSettings> mongoDbSettings, CancellationToken token = default, IDatabaseFactory mongoDatabaseFactory)
        {
            _mongoDatabaseFactory = mongoDatabaseFactory;
            _collection = CreateCollection(token).Result;
        }

        private async Task<IMongoCollection<TEntity>> CreateCollection(CancellationToken token)
        {
            var database = await _mongoDatabaseFactory.Create(token);

            return database.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        public bool Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public TEntity GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> SearchFor(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
