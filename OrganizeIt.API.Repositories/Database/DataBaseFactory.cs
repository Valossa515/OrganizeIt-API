using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;
using OrganizeIt.API.Borders.Database;
using OrganizeIt.API.Shared;
using System.Diagnostics.CodeAnalysis;

namespace OrganizeIt.API.Repositories.Database
{
    [ExcludeFromCodeCoverage]
    public class DataBaseFactory : IDataBaseFactory
    {
        private readonly IMongoDatabase _database;
        private readonly ILogger _logger;

        public DataBaseFactory(ApplicationConfig appConfig, ILogger<DataBaseFactory> logger)
        {
            try
            {
                var mongoClient = new MongoClient(appConfig.ConnectionStrings.DefaultConnection);

                _database = mongoClient.GetDatabase(appConfig.ConnectionStrings.DatabaseName);

                _logger = logger;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error while connecting to the database");
                throw;
            }
        }
        public async Task<bool> CheckConnectionAsync()
        {
            try
            {
                await _database.RunCommandAsync((Command<BsonDocument>)"{ping:1}");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while checking the database connection");
                return false;
            }
        }

        public IMongoCollection<T> GetCollection<T>(string name) => _database.GetCollection<T>(name);

        public IMongoDatabase GetDatabase() => _database;

    }
}