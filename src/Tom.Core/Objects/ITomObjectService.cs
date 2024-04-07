using OneOf;
using OneOf.Types;
using Tom.Core.Exceptions;
using Tom.Core.History.Data;
using Tom.Core.Keys.Errors;
using Tom.Core.Objects.Commands;
using Tom.Core.Objects.Errors;

namespace Tom.Core.Objects;

/// <summary>
///     Service that facilitates interaction with TOM objects
/// </summary>
public interface ITomObjectService
{
    /// <summary>
    ///     Returns a collection of objects available to the user
    /// </summary>
    /// <param name="userId">User id</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A collection of objects available to the user</returns>
    Task<IEnumerable<TomObject>> GetAvailableObjects(Guid userId, CancellationToken cancellationToken);

    /// <summary>
    ///     Creates a new user object
    /// </summary>
    /// <param name="userId">User id</param>
    /// <param name="objectId">Object id</param>
    /// <param name="command">Object information</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Success if the operation is successful, otherwise an error is returned</returns>
    Task<OneOf<Success, TomObjectExists, TomObjectContainsDuplicateKeys, TomKeyNameInvalid>> CreateObject(
        Guid userId,
        Guid objectId,
        CreateTomObjectCommand command,
        CancellationToken cancellationToken);

    /// <summary>
    ///     Returns an object the user manages
    /// </summary>
    /// <param name="userId">User id</param>
    /// <param name="objectId">Object id</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Object if it is found, otherwise an error is returned</returns>
    Task<OneOf<TomObject, TomObjectNotFound>> GetObject(
            Guid userId,
            Guid objectId,
            CancellationToken cancellationToken);

    /// <summary>
    ///     Reads all readable keys of the object and returns a snapshot of their values
    /// </summary>
    /// <param name="userId">User id</param>
    /// <param name="objectId">Object id</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <exception cref="TagServerException">On any tag server exception</exception>
    /// <returns>A snapshot of all readable object keys</returns>
    Task<OneOf<TomSnapshot, TomObjectNotFound, TomKeyTypeIncompatible>> ReadValues(
            Guid userId,
            Guid objectId,
            CancellationToken cancellationToken);

    /// <summary>
    ///     Updates all writeable keys of the object
    /// </summary>
    /// <param name="userId">User id</param>
    /// <param name="objectId">Object id</param>
    /// <param name="keyValues">Values for the writeable keys</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <exception cref="TagServerException">On any tag server exception</exception>
    /// <returns>Success if the operation is successful, otherwise an error is returned</returns>
    Task<OneOf<Success, TomObjectNotFound, TomKeyTypeIncompatible>> UpdateValues(
            Guid userId,
            Guid objectId,
            Dictionary<string, object> keyValues,
            CancellationToken cancellationToken);

    /// <summary>
    ///     Updates object information
    /// </summary>
    /// <param name="userId">User id</param>
    /// <param name="objectId">Object id</param>
    /// <param name="command">Values to update the object information with. Null values are not used for update</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Success if the operation is successful, otherwise an error is returned</returns>
    Task<OneOf<Success, TomObjectNotFound>> UpdateObject(
        Guid userId,
        Guid objectId,
        UpdateTomObjectCommand command,
        CancellationToken cancellationToken);

    /// <summary>
    ///     Deletes an object with the passed id
    /// </summary>
    /// <param name="userId">User id</param>
    /// <param name="objectId">Object id</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Success if the operation is successful, otherwise an error is returned</returns>
    Task<OneOf<Success, TomObjectNotFound>> DeleteObject(
        Guid userId,
        Guid objectId,
        CancellationToken cancellationToken);

    /// <summary>
    ///     Adds a new key to the object
    /// </summary>
    /// <param name="userId">User id</param>
    /// <param name="objectId">Object id</param>
    /// <param name="keyDefinition">Definition of the key to be added</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Success if the operation is successful, otherwise an error is returned</returns>
    Task<OneOf<Success, TomObjectNotFound, TomObjectContainsDuplicateKeys>> AddKey(
        Guid userId,
        Guid objectId,
        TomKeyDefinition keyDefinition,
        CancellationToken cancellationToken);

    /// <summary>
    ///     Deletes a key from the object
    /// </summary>
    /// <param name="userId">User id</param>
    /// <param name="objectId">Object id</param>
    /// <param name="keyName">Name of the key to add</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Success if the operation is successful, otherwise an error is returned</returns>
    Task<OneOf<Success, TomObjectNotFound, TomKeyNameInvalid, TomObjectHasNoKeys>> DeleteKey(
        Guid userId,
        Guid objectId,
        string keyName,
        CancellationToken cancellationToken);
}