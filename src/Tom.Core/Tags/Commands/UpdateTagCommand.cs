namespace Tom.Core.Tags.Commands;

/// <summary>
///     Command to update the tag information. Only
///     initialized fields will be used for the update
/// </summary>
public record UpdateTagCommand
{
    /// <summary>
    ///     Friendly name of the tag
    /// </summary>
    public string? FriendlyName { get; init; }

    /// <summary>
    ///     Tag address on the tag server
    /// </summary>
    public string? Address { get; init; }

    /// <summary>
    ///     Desired tag type
    /// </summary>
    public TagType? Type { get; init; }

    /// <summary>
    ///     Desired tag access mode
    /// </summary>
    public AccessMode? Mode { get; init; }
}