using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using OrganizeIt.API.Borders.Database;
using OrganizeIt.API.Borders.Entities;
using OrganizeIt.API.Shared.Attributies;
using OrganizeIt.API.Shared.Extensions;

namespace OrganizeIt.API.Repositories.Database
{
    public abstract class DatabaseRepository<TEntity, TId>(IDataBaseFactory databaseFactory,
        ILogger logger) where TEntity : DatabaseEntityBase<TId> where TId : struct
    {
        protected readonly ILogger _logger = logger;

        protected readonly IMongoCollection<TEntity> _collection =
            databaseFactory
            .GetDatabase()
            .GetCollection<TEntity>(typeof(TEntity)
            .GetAttributeValue((BsonCollectionAttribute x) => x.CollectionName));

        public virtual async Task<TEntity> GetByIdAsync(TId id)
        {
            var filter = Builders<TEntity>.Filter.Eq(x => x.Id, id);
            return await _collection.Find(filter).FirstOrDefaultAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
            => await _collection.Find(Builders<TEntity>.Filter.Empty).ToListAsync();

        public virtual async Task DeleteAllAsync(TEntity entity)
            => await _collection.DeleteManyAsync(Builders<TEntity>.Filter.Empty);

        public virtual async Task InsertAllAsync(IEnumerable<TEntity> entities)
            => await _collection.InsertManyAsync(entities);

        public virtual async Task InsertOneAsync(TEntity entity)
            => await _collection.InsertOneAsync(entity);
    }
}