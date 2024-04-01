using System.ComponentModel.DataAnnotations;
using Tom.Core.Keys;

namespace Tom.Core.Objects;

/// <summary>
///     TOM object defines a schema that can be used to read data
///     from the tag server or update data on the tag server.
///     The object has a specific owner for the purposes of
/// </summary>
public class TomObject
{
    /// <summary>
    ///     Object id
    /// </summary>
    public required Guid Id { get; init; }

    /// <summary>
    ///     Id of a user that created this object
    /// </summary>
    public required Guid OwnerId { get; init; }

    /// <summary>
    ///     Time the object has been created at
    /// </summary>
    public required DateTimeOffset CreatedAt { get; init; }

    /// <summary>
    ///     A collection of keys that represent the object
    /// </summary>
    [MinLength(1)]
    public required List<TomKey> Keys { get; init; }
}