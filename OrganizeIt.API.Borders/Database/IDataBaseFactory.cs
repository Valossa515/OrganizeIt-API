using MongoDB.Driver;

namespace OrganizeIt.API.Borders.Database
{
    public interface IDataBaseFactory
    {
        IMongoDatabase GetDatabase();
        IMongoCollection<T> GetCollection<T>(string name);
        Task<bool> CheckConnectionAsync();
    }
}