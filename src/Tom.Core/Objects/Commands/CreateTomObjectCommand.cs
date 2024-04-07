using System.ComponentModel.DataAnnotations;

namespace Tom.Core.Objects.Commands;

/// <summary>
///     Command to create an object
/// </summary>
public record CreateTomObjectCommand
{
    /// <summary>
    ///     Optional parameter to define when the object has been created
    /// </summary>
    public DateTimeOffset CreatedAt { get; init; } = DateTimeOffset.UtcNow;

    /// <summary>
    ///     Friendly name of the object
    /// </summary>
    public required string FriendlyName { get; init; }

    /// <summary>
    ///     Definitions to create the key set of the object
    /// </summary>
    [MinLength(1)]
    public required List<TomKeyDefinition> Keys { get; init; }
}