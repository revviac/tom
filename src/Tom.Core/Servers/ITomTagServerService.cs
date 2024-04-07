using OneOf;
using OneOf.Types;
using Tom.Core.Servers.Commands;
using Tom.Core.Servers.Errors;

namespace Tom.Core.Servers;

/// <summary>
///     Service that facilitates interaction with tag servers
/// </summary>
public interface ITomTagServerService
{
    /// <summary>
    ///     Returns a collection of all available servers
    /// </summary>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A collection of all available servers</returns>
    Task<IEnumerable<TagServer>> GetAvailableServers(CancellationToken cancellationToken);

    /// <summary>
    ///     Creates a tag server with the given id
    /// </summary>
    /// <param name="serverId">Server id</param>
    /// <param name="command">Server information</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Success if the operation is successful, otherwise an error is returned</returns>
    Task<OneOf<Success, TagServerExists>> CreateServer(Guid serverId, CreateTagServerCommand command,
        CancellationToken cancellationToken);

    /// <summary>
    ///     Returns a server with the passed id
    /// </summary>
    /// <param name="serverId">Server id</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Tag server with the passed id if its found, otherwise an error is returned</returns>
    Task<OneOf<TagServer, TagServerNotFound>> GetServer(Guid serverId, CancellationToken cancellationToken);

    /// <summary>
    ///     Updates the tag server with values from the command
    /// </summary>
    /// <param name="serverId">Server id</param>
    /// <param name="command">Values to update the server information with. Null values are not used for update</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Success if the operation is successful, otherwise an error is returned</returns>
    Task<OneOf<Success, TagServerNotFound>> UpdateServer(Guid serverId, UpdateTagServerCommand command, CancellationToken cancellationToken);

    /// <summary>
    ///     Deletes the server with the given id
    /// </summary>
    /// <param name="serverId">Server id</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Success if the operation is successful, otherwise an error is returned</returns>
    Task<OneOf<Success, TagServerNotFound>> DeleteServer(Guid serverId, CancellationToken cancellationToken);
}