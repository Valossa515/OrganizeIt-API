namespace OrganizeIt.API.Shared.Extensions
{
    public static class AttributeExtensions
    {
        public static TValue? GetAttributeValue<TAttributem, TValue>(
                this Type? type,
                Func<TAttributem, TValue> valueSelector)
                where TAttributem : Attribute
        {
            return type?.GetCustomAttributes(
                typeof(TAttributem), true
            ).FirstOrDefault() is TAttributem attribute
                ? valueSelector(attribute)
                : default;
        }
    }
}