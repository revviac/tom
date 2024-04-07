using OneOf;
using OneOf.Types;
using Tom.Core.Exceptions;
using Tom.Core.History.Data;
using Tom.Core.History.Options;
using Tom.Core.Tags;
using Tom.Core.Tags.Errors;

namespace Tom.Core.History;

/// <summary>
///     Interface for retrieving a snapshot history of a tag from an abstract time series storage.
/// </summary>
public interface IHistoryService
{
    /// <summary>
    ///     Reads the current value of a tag and returns a snapshot of its value
    /// </summary>
    /// <param name="tag">Tag to read</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <exception cref="TagServerException">On any tag server exception</exception>
    /// <returns>
    /// The current snapshot of the tag if the read is successful,
    /// otherwise an error is returned
    /// </returns>
    Task<OneOf<TomSnapshot, TagNotFound, TagTypeIncompatible>> ReadLatestSnapshot(
        Tag tag,
        CancellationToken cancellationToken);

    /// <summary>
    ///     Reads the current value of a tag and returns a snapshot of its value
    /// </summary>
    /// <param name="tag">Tag to read</param>
    /// <param name="historyOptions">Shape of history to return</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <exception cref="TagServerException">On any tag server exception</exception>
    /// <returns>
    /// Snapshot history of the tag if the read is successful, otherwise an error is returned
    /// </returns>
    Task<OneOf<TomSnapshotHistory, TagNotFound, TagTypeIncompatible>> ReadSnapshotHistory(
        Tag tag,
        HistoryOptions historyOptions,
        CancellationToken cancellationToken);

    /// <summary>
    ///     Saves the value to the history of a tag
    /// </summary>
    /// <param name="tag">Tag to save the value of</param>
    /// <param name="value">Value to save</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <typeparam name="T">Value type</typeparam>
    /// <exception cref="TagServerException">On any tag server exception</exception>
    /// <returns>Success if the operation is successful, otherwise an error is returned</returns>
    Task<OneOf<Success, TagNotFound, TagTypeIncompatible>> SaveSnapshot<T>(
        Tag tag,
        T value,
        CancellationToken cancellationToken
    );
}