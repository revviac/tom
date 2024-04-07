using OneOf;
using OneOf.Types;
using Tom.Core.History.Data;
using Tom.Core.Keys.Errors;
using Tom.Core.Objects.Errors;
using Tom.Core.Tags;

namespace Tom.Core.Keys;

/// <summary>
///     Service that facilitates interaction with the TOM keys.
/// </summary>
public interface ITomKeyService
{
    /// <summary>
    ///     Returns a key of a specific object among user resources.
    /// </summary>
    /// <param name="userId">User id</param>
    /// <param name="objectId">Id of an object among user resources</param>
    /// <param name="keyName">Key name</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>
    /// Key belonging to the user object. On any error, it is returned instead
    /// </returns>
    Task<OneOf<TomKey, TomObjectNotFound, TomKeyNameInvalid, TomKeyNotFound>> GetKey(
        Guid userId,
        Guid objectId,
        string keyName,
        CancellationToken cancellationToken);

    /// <summary>
    ///     Returns a tag that's connected to the specified key.
    /// </summary>
    /// <param name="userId">User id</param>
    /// <param name="objectId">Id of an object among user resources</param>
    /// <param name="keyName">Key name</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>
    /// Tag of a key belonging to the user object. On any error, it is returned instead
    /// </returns>
    Task<OneOf<Tag, TomObjectNotFound, TomKeyNameInvalid, TomKeyNotFound>> GetKeyTag(
        Guid userId,
        Guid objectId,
        string keyName,
        CancellationToken cancellationToken
    );

    /// <summary>
    ///     Reads a key and returns a snapshot of its value
    /// </summary>
    /// <param name="userId">User id</param>
    /// <param name="objectId">Id of an object among user resources</param>
    /// <param name="keyName">Key name</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>
    /// Snapshot of a key belonging to the user object. On any error, it is returned instead
    /// </returns>
    Task<
        OneOf<TomSnapshot, TomObjectNotFound, TomKeyNameInvalid, TomKeyNotFound, TomKeyTypeIncompatible, TomKeyAccessModeViolated>
    > ReadKeyValue(
        Guid userId,
        Guid objectId,
        string keyName,
        CancellationToken cancellationToken
    );

    /// <summary>
    ///     Reads a key and returns a snapshot of its value
    /// </summary>
    /// <param name="userId">User id</param>
    /// <param name="objectId">Id of an object among user resources</param>
    /// <param name="keyName">Key name</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>
    /// Snapshot of a key belonging to the user object. On any error, it is returned instead
    /// </returns>
    Task<OneOf<TomSnapshotHistory, TomObjectNotFound, TomKeyNameInvalid, TomKeyNotFound, TomKeyTypeIncompatible>> ReadHistory(
        Guid userId,
        Guid objectId,
        string keyName,
        CancellationToken cancellationToken
    );

    /// <summary>
    ///     Updates the value of a key if the types are compatible
    /// </summary>
    /// <param name="userId">User id</param>
    /// <param name="objectId">Id of an object among user resources</param>
    /// <param name="keyName">Key name</param>
    /// <param name="value">Value to use</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <typeparam name="T">Value type that will be used to check key type compatibility</typeparam>
    /// <returns>Success if the operation is successful, otherwise an error is returned</returns>
    Task<
        OneOf<Success, TomObjectNotFound, TomKeyNameInvalid, TomKeyNotFound, TomKeyTypeIncompatible, TomKeyAccessModeViolated>
    > UpdateValue<T>(
        Guid userId,
        Guid objectId,
        string keyName,
        T value,
        CancellationToken cancellationToken
    );

    /// <summary>
    ///     Changes the tag that the key is connected to
    /// </summary>
    /// <param name="userId">User id</param>
    /// <param name="objectId">Id of an object among user resources</param>
    /// <param name="keyName">Key name</param>
    /// <param name="newTag">Tag that should be used by the key</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Success if the operation is successful, otherwise an error is returned</returns>
    Task<OneOf<Success, TomObjectNotFound, TomKeyNameInvalid, TomKeyNotFound, TomKeyTypeIncompatible>> ChangeTag(
        Guid userId,
        Guid objectId,
        string keyName,
        Tag newTag,
        CancellationToken cancellationToken
    );
}