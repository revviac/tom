namespace Tom.Core.Objects.Commands;

/// <summary>
///     Defines a set of attributes that are sufficient to
///     add a new key to the object.
/// </summary>
public record TomKeyDefinition
{
    /// <summary>
    ///     Key name
    /// </summary>
    public required string Name { get; init; }

    /// <summary>
    ///     Tag the key is connected to
    /// </summary>
    public required Guid TagId { get; init; }
}