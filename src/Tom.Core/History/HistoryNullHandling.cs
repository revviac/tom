namespace Tom.Core.History;

/// <summary>
///     Describes how null values should be handled when encountered during history retrieval
/// </summary>
public enum HistoryNullHandling
{
    /// <summary>
    ///     Nulls are left without any kind of processing
    /// </summary>
    NoHandling,

    /// <summary>
    ///     Nulls are dropped
    /// </summary>
    Drop,

    /// <summary>
    ///     Null values are interpolated (only allowed for values of type double)
    /// </summary>
    LinearInterpolation,

    /// <summary>
    ///     Last Observation Carried Forward (LOCF) is used
    /// </summary>
    LOCF
}