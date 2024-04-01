using Tom.Core.Servers;

namespace Tom.Core.Tags;

/// <summary>
///     Describes tag information
/// </summary>
public class Tag
{
    /// <summary>
    ///     Returns a stub tag with the passed id and tag type.
    ///     Created tag has the <see cref="AccessMode.ReadWrite"/> access mode
    /// </summary>
    /// <param name="id">Tag id</param>
    /// <param name="type">Tag type</param>
    /// <returns>A stub tag</returns>
    public static Tag GetStub(Guid id, TagType type) => new()
    {
        Id = id,
        TagServer = TagServer.GetStub(),
        TagAddress = "",
        Type = type,
        Mode = AccessMode.ReadWrite
    };

    /// <summary>
    ///     Returns a stub tag with a random guid as the id and the passed tag type.
    ///     Created tag has the <see cref="AccessMode.ReadWrite"/> access mode
    /// </summary>
    /// <param name="type">Tag type</param>
    /// <returns>A stub tag</returns>
    public static Tag GetStub(TagType type) => GetStub(Guid.NewGuid(), type);

    /// <summary>
    ///     Unique tag id
    /// </summary>
    public required Guid Id { get; init; }

    /// <summary>
    ///     Server that the tag is connected to
    /// </summary>
    public required TagServer TagServer { get; set; }

    /// <summary>
    ///     Tag address on the server
    /// </summary>
    public required string TagAddress { get; set; }

    /// <summary>
    ///     Tag type
    /// </summary>
    public required TagType Type { get; init; }

    /// <summary>
    ///     Tag access mode
    /// </summary>
    public required AccessMode Mode { get; set; }

    /// <summary>
    ///     Whether the tag is a stub tag, meaning its value lies in cache
    /// </summary>
    public bool IsStub => TagAddress is "" && TagServer.Address is "";

    /// <summary>
    ///     Tag server id
    /// </summary>
    public Guid ServerId { get; set; } = default;
}