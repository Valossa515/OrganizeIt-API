using System.Diagnostics.CodeAnalysis;

namespace OrganizeIt.API.Shared.Attributies
{
    [AttributeUsage(AttributeTargets.Class)]
    [ExcludeFromCodeCoverage]
    public class BsonCollectionAttribute(string collectionName) : Attribute
    {
        public string CollectionName { get; } = collectionName;
    }
}