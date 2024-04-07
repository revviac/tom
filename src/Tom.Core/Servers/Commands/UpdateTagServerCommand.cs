namespace Tom.Core.Servers.Commands;

/// <summary>
///     Command to update the tag server information. Only
///     initialized fields will be used for the update
/// </summary>
public record UpdateTagServerCommand
{
    /// <summary>
    ///     Desired server address
    /// </summary>
    public string? Address { get; init; }

    /// <summary>
    ///     Desired server friendly name
    /// </summary>
    public string? FriendlyName { get; init; }
}