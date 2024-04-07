namespace Tom.Core.Tags;

public static class TagTypeValidator
{
    public static bool TypesCompatible(Type type, TagType tagType)
    {
        return tagType switch
        {
            TagType.Float => typeof(float).IsAssignableFrom(type),
            TagType.Double => typeof(double).IsAssignableFrom(type),
            TagType.Int => typeof(int).IsAssignableFrom(type),
            TagType.Long => typeof(long).IsAssignableFrom(type),
            _ => throw new ArgumentOutOfRangeException(nameof(tagType), tagType, null)
        };
    }
}