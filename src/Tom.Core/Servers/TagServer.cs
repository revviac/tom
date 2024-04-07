using Tom.Core.Servers.Commands;

namespace Tom.Core.Servers;


/// <summary>
///     Object that stores information about the tag server
/// </summary>
public class TagServer
{
    /// <summary>
    ///     Returns a stub server with an empty id
    /// </summary>
    /// <returns>A stub server with an empty id</returns>
    public static TagServer GetStub() => GetStub(Guid.Empty);

    /// <summary>
    ///     Returns a stub server with the specified id
    /// </summary>
    /// <param name="id">Server id</param>
    /// <returns>A stub server with a specified id</returns>
    public static TagServer GetStub(Guid id)
    {
        return new TagServer
        {
            Id = id,
            Address = "",
            Type = ServerType.StubServer,
            FriendlyName = "Stub server",
            CreatedAt = DateTimeOffset.UtcNow
        };
    }

    /// <summary>
    ///     Server id
    /// </summary>
    public required Guid Id { get; init; }

    /// <summary>
    ///     Server address
    /// </summary>
    public required string Address { get; set; }

    /// <summary>
    ///     Friendly name for the server that can be passed to the user
    /// </summary>
    public required string FriendlyName { get; set; }

    /// <summary>
    ///     Time that the server was created at
    /// </summary>
    public required DateTimeOffset CreatedAt { get; init; }

    /// <summary>
    ///     Server type
    /// </summary>
    public required ServerType Type { get; init; }

    /// <summary>
    ///     Updates tag server information with values from the command
    /// </summary>
    /// <param name="command">Values to update the server information with</param>
    public void Update(UpdateTagServerCommand command)
    {
        if (command.Address != null)
            Address = command.Address;

        if (command.FriendlyName != null)
            FriendlyName = command.FriendlyName;
    }
}