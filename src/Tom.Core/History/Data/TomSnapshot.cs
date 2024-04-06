using System.Text.Json;
using OneOf;
using Tom.Core.Errors;
using Tom.Core.Tags;

namespace Tom.Core.History.Data;

using static TagTypeValidator;

/// <summary>
///     Represents a snapshot of a TOM key or object.
///     The true type of the snapshot value can only be interpreted
///     in a context.
/// </summary>
public class TomSnapshot
{
    /// <summary>
    ///     The timestamp that the snapshot has been taken at.
    ///     If not instantiated, it defaults to the current server UTC time
    /// </summary>
    public DateTimeOffset Timestamp { get; private set; }

    /// <summary>
    ///     The value of the snapshot
    /// </summary>
    public object Value { get; set; }

    /// <summary>
    ///     The tag type of the underlying value
    /// </summary>
    public TagType Type { get; init; }

    /// <summary>
    ///     Returns a data point with a timestamp and a casted value if the requested type and the tag type of
    ///     the snapshot are compatible
    /// </summary>
    /// <typeparam name="T">Type to cast the value as</typeparam>
    /// <returns>A data point if the cast is successful</returns>
    public OneOf<DataPoint<T>, TagTypeIncompatible> Unwrap<T>()
    {
        if (TypesCompatible(typeof(T), Type))
        {
            return new DataPoint<T>(Timestamp, (T)Value);
        }

        return new TagTypeIncompatible(JsonSerializer.Serialize(Value), Type);
    }

    public TomSnapshot(DateTimeOffset timestamp, object value, TagType tagType)
    {
        Timestamp = timestamp;
        Value = value;
        Type = tagType;
    }

    public TomSnapshot(object value, TagType tagType) : this(DateTimeOffset.UtcNow, value, tagType) { }
}