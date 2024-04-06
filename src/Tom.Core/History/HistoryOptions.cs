namespace Tom.Core.History;

/// <summary>
///     Describes the resulting history shape
/// </summary>
public record HistoryOptions
{
    /// <summary>
    ///     Start time for the history
    /// </summary>
    public DateTimeOffset? FromUtc { get; init; }

    /// <summary>
    ///     End time for the history
    /// </summary>
    public DateTimeOffset? ToUtc { get; init; }

    /// <summary>
    ///     If specified, the fetched history should be the latest history
    ///     over the period. Must take precedence over FromUtc and ToUtc parameters
    /// </summary>
    public TimeSpan? Period { get; init; }

    /// <summary>
    ///     Maximum number of points that can appear in history
    /// </summary>
    public uint? MaxNumPoints { get; init; }

    /// <summary>
    ///     If specified, the history should be resampled so that each observation is BucketSize away from another
    /// </summary>
    public HistoryResamplingOptions? ResamplingOptions { get; init; }

    /// <summary>
    ///     Rule to be used for null values (or empty buckets if the history is resampled)
    /// </summary>
    public HistoryNullHandling NullHandling { get; init; } = HistoryNullHandling.NoHandling;

    /// <summary>
    ///     Describes how the values should be ordered in the retrieved history
    /// </summary>
    public HistoryOrdering Ordering { get; init; } = HistoryOrdering.OldestFirst;
}