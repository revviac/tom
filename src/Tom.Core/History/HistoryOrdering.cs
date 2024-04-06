namespace Tom.Core.History;

/// <summary>
///     Describes how the history values should be ordered
/// </summary>
public enum HistoryOrdering
{
    /// <summary>
    ///     Newest values are located in the beginning of history
    /// </summary>
    NewestFirst,

    /// <summary>
    ///     Oldest values are located in the beginning of history
    /// </summary>
    OldestFirst
}