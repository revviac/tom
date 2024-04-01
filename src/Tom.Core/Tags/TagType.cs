namespace Tom.Core.Tags;

/// <summary>
///     Common tag types. TOM supports only basic
/// </summary>
public enum TagType
{
    /// <summary>
    ///     Tag stores float32 values
    /// </summary>
    Float = 1,

    /// <summary>
    ///     Tag stores float64 values
    /// </summary>
    Double = 2,

    /// <summary>
    ///     Tag stores int32 values
    /// </summary>
    Int = 3,

    /// <summary>
    ///     Tag stores int64 values
    /// </summary>
    Long = 4,
}