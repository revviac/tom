namespace Tom.Core.History;

public record HistoryResamplingOptions
{
    /// <summary>
    ///     Size of the bucket
    /// </summary>
    public TimeSpan BucketSize { get; init; }

    /// <summary>
    ///     Aggregation rule for values that fall within the same bucket
    /// </summary>
    public BucketAggregationMode AggregationMode { get; init; } = BucketAggregationMode.MinAcrossBucket;
}