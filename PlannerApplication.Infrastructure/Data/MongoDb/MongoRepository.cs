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
            _collection = CreateCollection().Result;
        }

        public bool Delete(T entity)
        {
            var filter = Builders<T>.Filter.Eq(r => r.Id, entity.Id);

            return _collection.DeleteOne(filter).DeletedCount > 0;
        }

        public Task<bool> DeleteAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetAll()
        {
            return (IQueryable<T>)_collection.Find(Builders<T>.Filter.Empty);
        }

        public Task<IQueryable<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public T? GetById(int id)
        {
            return _collection.AsQueryable().Where(r => r.Id == id).FirstOrDefault();
        }

        public Task<T> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public T Insert(T entity)
        {
            _collection.InsertOne(entity);
            return entity;
        }

        public async Task<T> InsertAsync(T entity)
        {
            await _collection.InsertOneAsync(entity);
            return entity;
        }

        public IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate)
        {
            return (IQueryable<T>)_collection.AsQueryable<T>().Where(predicate.Compile());
        }

        public Task<IQueryable<T>> SearchForAsync(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(T entity)
        {
            var filter = Builders<T>.Filter.Eq(_ => _.Id, entity.Id);
            var update = Builders<T>.Update.Set(u => u, entity);

            return _collection.UpdateOne(filter, update).ModifiedCount > 0;
        }

        public Task<bool> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }

        #region Private Methods
        private async Task<IMongoCollection<T>> CreateCollection()
        {
            var database = await _mongoDatabaseFactory.Create(new CancellationToken());
            var getCollectionMethod = database.GetType().GetMethod(nameof(IMongoDatabase.GetCollection));
            var definition = getCollectionMethod!.GetGenericMethodDefinition();
            var getCollection = getCollectionMethod.MakeGenericMethod(new Type[] { typeof(T) });
            var result = getCollection!.Invoke(database, new object[] { nameof(T), new MongoCollectionSettings() });

            return (IMongoCollection<T>)result!;
        }
        #endregion
    }
}
