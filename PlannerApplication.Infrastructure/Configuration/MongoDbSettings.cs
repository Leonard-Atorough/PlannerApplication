using MongoDB.Driver;

namespace PlannerApplication.Infrastructure.Configuration
{
    public class MongoDbSettings
    {
        public string ConnectionName { get; set; } = string.Empty;
        public string ConnectionUrl { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
    }
}