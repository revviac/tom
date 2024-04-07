namespace Tom.Core.Tags.Commands;

/// <summary>
///     Command to create a tag
/// </summary>
public record CreateTagCommand
{
    /// <summary>
    ///     Time the tag was created at
    /// </summary>
    public required DateTimeOffset CreatedAt { get; init; }

    /// <summary>
    ///     Friendly name of the tag
    /// </summary>
    public required string FriendlyName { get; init; }

    /// <summary>
    ///     Server that the tag is connected to
    /// </summary>
    public required Guid ServerId { get; init; }

    /// <summary>
    ///     Tag address on the tag server
    /// </summary>
    public required string Address { get; init; }

    /// <summary>
    ///     Tag type
    /// </summary>
    public required TagType Type { get; init; }

    /// <summary>
    ///     Tag access mode
    /// </summary>
    public required AccessMode Mode { get; init; }
}