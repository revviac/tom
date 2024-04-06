namespace Tom.Core.History;

/// <summary>
///     Describes how the value of a bucket with multiple
///     values should be estimated
/// </summary>
public enum BucketAggregationMode
{
    /// <summary>
    ///     Takes the average value across the bucket (only allowed for values of type double)
    /// </summary>
    AverageAcrossBucket,

    /// <summary>
    ///     Takes the minimal value across the bucket
    /// </summary>
    MinAcrossBucket,

    /// <summary>
    ///     Takes the maximum value across the bucket
    /// </summary>
    MaxAcrossBucket,
}