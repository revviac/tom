namespace Tom.Core.Servers;

/// <summary>
///     Describes supported server types
/// </summary>
public enum ServerType
{
    /// <summary>
    ///     OPC UA server
    /// </summary>
    OpcUa = 1,

    /// <summary>
    ///     A stub server
    /// </summary>
    StubServer = 2,
}