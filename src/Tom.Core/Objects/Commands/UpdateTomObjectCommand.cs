namespace Tom.Core.Objects.Commands;

/// <summary>
///     Command to update the object. Only
///     initialized fields will be used for the update
/// </summary>
public record UpdateTomObjectCommand
{
    public string? FriendlyName { get; init; }
}