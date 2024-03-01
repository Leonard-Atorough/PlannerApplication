using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PlannerApplication.Core.Entities;
using PlannerApplication.Core.Interfaces;
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
            return _collection.AsQueryable().Where(r => r.Id == id).FirstOrDefault();
            //try
            //{
            //    return _collection.AsQueryable().Where(r => r.Id == id).Single();

            //}
            //catch (ArgumentNullException)
            //{
            //    throw;
            //}
        }

        public void Insert(TEntity entity)
        {
            _collection.InsertOne(entity);
        }

        public IQueryable<TEntity> SearchFor(Expression<Func<TEntity, bool>> predicate)
        {
            return (IQueryable<TEntity>)_collection.AsQueryable<TEntity>().Where(predicate.Compile());
        }

        public bool Update(TEntity entity)
        {
            var filter = Builders<TEntity>.Filter.Eq(_ => _.Id, entity.Id);
            var update = Builders<TEntity>.Update.Set(u => u, entity);

            return _collection.UpdateOne(filter, update).ModifiedCount > 0;
        }
    }
}
