namespace Tom.Core.Servers.Commands;

/// <summary>
///     Command to create the tag server
/// </summary>
public record CreateTagServerCommand
{
    /// <summary>
    ///     Server address
    /// </summary>
    public required string Address { get; init; }

    /// <summary>
    ///     Friendly name for the server that can be passed to the user
    /// </summary>
    public required string FriendlyName { get; init; }

    /// <summary>
    ///     Time that the server was created at
    /// </summary>
    public required DateTimeOffset CreatedAt { get; init; } = DateTimeOffset.UtcNow;

    /// <summary>
    ///     Server type
    /// </summary>
    public required ServerType Type { get; init; }
}