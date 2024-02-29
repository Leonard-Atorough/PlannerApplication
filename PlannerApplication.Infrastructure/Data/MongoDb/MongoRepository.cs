using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PlannerApplication.Core.Entities;
using PlannerApplication.Infrastructure.Configuration;
using System.Linq.Expressions;

namespace PlannerApplication.Infrastructure.Data.MongoDb
{
    public class MongoRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly IDatabaseFactory<IMongoDatabase> _mongoDatabaseFactory;

        private readonly IMongoCollection<TEntity> _collection;

        public MongoRepository(IDatabaseFactory<IMongoDatabase> mongoDatabaseFactory, CancellationToken token = default)
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
            var filter = Builders<TEntity>.Filter.Eq(r => r.Id, entity.Id);

            return _collection.DeleteOne(filter).DeletedCount > 0;
        }

        public IQueryable<TEntity> GetAll()
        {
            return (IQueryable<TEntity>)_collection.Find(Builders<TEntity>.Filter.Empty);
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
