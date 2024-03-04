using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PlannerApplication.Core.Entities;
using PlannerApplication.Core.Interfaces;
using PlannerApplication.Infrastructure.Configuration;
using System.Linq.Expressions;

namespace PlannerApplication.Infrastructure.Data.MongoDb
{
    public class MongoRepository<T> : IRepository<T> where T : class, IAggregateRoot, IEntity
    {
        private readonly IDatabaseFactory<IMongoDatabase> _mongoDatabaseFactory;

        private readonly IMongoCollection<T> _collection;

        public MongoRepository(IDatabaseFactory<IMongoDatabase> mongoDatabaseFactory, CancellationToken token = default)
        {
            _mongoDatabaseFactory = mongoDatabaseFactory;
            _collection = CreateCollection(token).Result;
        }

        public bool Delete(T entity)
        {
            var filter = Builders<T>.Filter.Eq(r => r.Id, entity.Id);

            return _collection.DeleteOne(filter).DeletedCount > 0;
        }

        public IQueryable<T> GetAll()
        {
            return (IQueryable<T>)_collection.Find(Builders<T>.Filter.Empty);
        }

        public T? GetById(int id)
        {
            return _collection.AsQueryable().Where(r => r.Id == id).FirstOrDefault();
        }

        public void Insert(T entity)
        {
            _collection.InsertOne(entity);
        }

        public IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate)
        {
            return (IQueryable<T>)_collection.AsQueryable<T>().Where(predicate.Compile());
        }

        public bool Update(T entity)
        {
            var filter = Builders<T>.Filter.Eq(_ => _.Id, entity.Id);
            var update = Builders<T>.Update.Set(u => u, entity);

            return _collection.UpdateOne(filter, update).ModifiedCount > 0;
        }

        #region Private Methods
        private async Task<IMongoCollection<T>> CreateCollection(CancellationToken token)
        {
            var database = await _mongoDatabaseFactory.Create(token);

            return database.GetCollection<T>(typeof(T).Name);
        }
        #endregion
    }
}
