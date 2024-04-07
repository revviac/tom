namespace Tom.Core.Tags;

/// <summary>
///     Type of operation that's done on the tag
/// </summary>
public enum AccessOperation
{
    /// <summary>
    ///     The tag is read
    /// </summary>
    Read,

    /// <summary>
    ///     The tag is written to
    /// </summary>
    Write
}