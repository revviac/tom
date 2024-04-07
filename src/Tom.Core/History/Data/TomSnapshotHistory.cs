using System.Text.Json;
using OneOf;
using Tom.Core.History.Options;
using Tom.Core.Tags;
using Tom.Core.Tags.Errors;

namespace Tom.Core.History.Data;

using static TagTypeValidator;

/// <summary>
///     Represents a history of snapshots
/// </summary>
public class TomSnapshotHistory
{
    public TagType Type { get; init; }

    public HistoryOptions Options { get; init; }

    public IEnumerable<DateTimeOffset> Timestamps { get; init; }

    public IEnumerable<object> Values { get; init; }

    /// <summary>
    ///     Returns a collection of data points with timestamps and casted values if the requested type and
    ///     the tag type of the snapshots are compatible
    /// </summary>
    /// <typeparam name="T">Type to cast the value as</typeparam>
    /// <returns>A collection of data points if the cast is successful</returns>
    public OneOf<IEnumerable<DataPoint<T>>, TagTypeIncompatible> Unwrap<T>()
    {
        if (TypesCompatible(typeof(T), Type))
        {
            var history = Timestamps.Zip(Values, (timestamp, value) => new DataPoint<T>(timestamp, (T)value));
            return OneOf<IEnumerable<DataPoint<T>>, TagTypeIncompatible>.FromT0(history);
        }

        return new TagTypeIncompatible(JsonSerializer.Serialize(Values), Type);
    }

    public TomSnapshotHistory(
        IEnumerable<DateTimeOffset> timestamps,
        IEnumerable<object> values,
        HistoryOptions options,
        TagType tagType)
    {
        Timestamps = timestamps;
        Values = values;
        Options = options;
        Type = tagType;
    }
}