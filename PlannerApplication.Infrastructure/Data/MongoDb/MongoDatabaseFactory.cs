using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PlannerApplication.Infrastructure.Configuration;

namespace PlannerApplication.Infrastructure.Data.MongoDb
{
    public class MongoDatabaseFactory : IDatabaseFactory<IMongoDatabase>
    {
        private readonly MongoDbSettings _settings;
        private readonly ILogger _logger;


        public MongoDatabaseFactory(IOptions<MongoDbSettings> settings, ILogger<MongoDatabaseFactory> logger)
        {
            _logger = logger;
            _settings = settings.Value;
        }

        public async Task<IMongoDatabase> Create(CancellationToken token)
        {
            //Create Client
            var client = new MongoClient(new MongoUrl(_settings.ConnectionUrl));

            //CreateOrRetrieveDatabase
            var dbName = _settings.DatabaseName;
            var names = await (await client.ListDatabaseNamesAsync().ConfigureAwait(false)).ToListAsync(token).ConfigureAwait(false);
            if (!names.Any(x => x.Equals(dbName, StringComparison.InvariantCulture)))
            {
                _logger.LogInformation($"Database {dbName} does not yet exist. Creating {dbName}...");
            }
            return client.GetDatabase(dbName);
        }
    }
}