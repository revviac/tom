using OneOf;
using OneOf.Types;
using Tom.Core.Exceptions;
using Tom.Core.History.Data;
using Tom.Core.History.Options;
using Tom.Core.Keys.Errors;
using Tom.Core.Servers.Errors;
using Tom.Core.Tags.Commands;
using Tom.Core.Tags.Errors;

namespace Tom.Core.Tags;

/// <summary>
///     Service that facilitates interaction with tags
/// </summary>
public interface ITomTagService
{
    /// <summary>
    ///     Returns a collection of available tags
    /// </summary>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A collection of tags</returns>
    Task<IEnumerable<Tag>> GetAvailableTags(CancellationToken cancellationToken);

    /// <summary>
    ///     Creates a tag with the given id
    /// </summary>
    /// <param name="tagId">Tag id</param>
    /// <param name="command">Tag information</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Success if the operation is successful, otherwise an error is returned</returns>
    Task<OneOf<Success, TagServerNotFound, TagExists>> CreateTag(
        Guid tagId,
        CreateTagCommand command,
        CancellationToken cancellationToken);

    /// <summary>
    ///     Returns a tag with the passed id
    /// </summary>
    /// <param name="tagId">Tag id</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Tag if it's found</returns>
    Task<OneOf<Tag, TagNotFound>> GetTag(Guid tagId, CancellationToken cancellationToken);

    /// <summary>
    ///     Returns a snapshot of the tag value
    /// </summary>
    /// <param name="tagId">Tag id</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <exception cref="TagServerException">On any tag server exception</exception>
    /// <returns>A snapshot of the tag value</returns>
    Task<OneOf<TomSnapshot, TagNotFound, TagAccessModeViolated>> ReadTagValue(Guid tagId, CancellationToken cancellationToken);

    /// <summary>
    ///     Returns the tag history
    /// </summary>
    /// <param name="tagId">Tag id</param>
    /// <param name="options">History options</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <exception cref="TagServerException">On any tag server exception</exception>
    /// <returns>Tag history</returns>
    Task<OneOf<TomSnapshotHistory, TagNotFound, TagAccessModeViolated>> ReadTagHistory(
        Guid tagId,
        HistoryOptions options,
        CancellationToken cancellationToken);

    /// <summary>
    ///     Updates the tag value
    /// </summary>
    /// <param name="tagId">Tag id</param>
    /// <param name="value">Value to use</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <typeparam name="T">Type of the value</typeparam>
    /// <exception cref="TagServerException">On any tag server exception</exception>
    /// <returns>Success if the operation is successful, otherwise an error is returned</returns>
    Task<OneOf<Success, TagNotFound, TagTypeIncompatible, TagAccessModeViolated>> UpdateTagValue<T>(
        Guid tagId,
        T value,
        CancellationToken cancellationToken);

    /// <summary>
    ///     Updates tag with values from the command
    /// </summary>
    /// <param name="tagId">Tag id</param>
    /// <param name="command">Values to update the tag information with. Null values are not used for update</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Success if the operation is successful, otherwise an error is returned</returns>
    Task<OneOf<Success, TagNotFound>> UpdateTag(Guid tagId, UpdateTagCommand command, CancellationToken cancellationToken);

    /// <summary>
    ///     Deletes tag with the passed id
    /// </summary>
    /// <param name="tagId">Tag id</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Success if the operation is successful, otherwise an error is returned</returns>
    Task<OneOf<Success, TagNotFound>> DeleteTag(Guid tagId, CancellationToken cancellationToken);
}