namespace Tom.Core.Servers;


/// <summary>
///     Object that stores information about the tag server
/// </summary>
public class TagServer
{
    public static TagServer GetStub()
    {
        return new TagServer
        {
            Id = Guid.Empty,
            Address = "",
            Type = ServerType.StubServer
        };
    }

    public static TagServer GetStub(Guid id)
    {
        return new TagServer
        {
            Id = id,
            Address = "",
            Type = ServerType.StubServer
        };
    }

    /// <summary>
    ///     Server id
    /// </summary>
    public required Guid Id { get; init; } = Guid.NewGuid();

    /// <summary>
    ///     Server address
    /// </summary>
    public string Address { get; set; } = "";

    /// <summary>
    ///     Friendly name for the server that can be passed to the user
    /// </summary>
    public string FriendlyName { get; set; } = "";

    /// <summary>
    ///     Server type
    /// </summary>
    public required ServerType Type { get; init; }
}