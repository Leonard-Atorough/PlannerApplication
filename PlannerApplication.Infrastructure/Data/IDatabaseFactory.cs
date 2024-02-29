using MongoDB.Driver;

namespace PlannerApplication.Infrastructure.Data
{
    public interface IDatabaseFactory
    {
        Task<IMongoDatabase> Create(CancellationToken token);
    }
}