using Tom.Core.Tags;

namespace Tom.Core.Keys;

/// <summary>
///     Object key used to retrieve information about tag
/// </summary>
public class TomKey
{
    /// <summary>
    ///     Key name that can be used for data retrieval
    /// </summary>
    public required string Name { get; init; }

    /// <summary>
    ///     Connected tag that will be used for reading/writing data
    /// </summary>
    public required Tag Tag { get; init; }

    /// <summary>
    ///     Tag access mode
    /// </summary>
    public AccessMode Mode => Tag.Mode;

    /// <summary>
    ///     Tag type
    /// </summary>
    public TagType Type => Tag.Type;

    /// <summary>
    ///     Connected tag id
    /// </summary>
    public Guid TagId { get; init; } = default;
}