using MongoDB.Driver;

namespace PlannerApplication.Infrastructure.Data
{
    public interface IDatabaseFactory<T> where T : class
    {
        Task<T> Create(CancellationToken token);
    }
}