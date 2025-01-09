using MongoDB.Bson.Serialization.Attributes;

namespace OrganizeIt.API.Borders.Entities
{
    public abstract class DatabaseEntityBase<TId> where TId : struct
    {
        [BsonId]
        public TId Id { get; set; }
    }
}