namespace Tom.Core.Tags;

/// <summary>
///     Access mode for the tag value
/// </summary>
[Flags]
public enum AccessMode
{
    /// <summary>
    ///     Tag can be read
    /// </summary>
    Readable = 0b01,

    /// <summary>
    ///     Tag can be written to
    /// </summary>
    Writeable = 0b10,

    /// <summary>
    ///     Tag can be both read and written to
    /// </summary>
    ReadWrite = 0b11,
}

public static class AccessModeExtensions
{
    public static bool IsReadable(this AccessMode value)
    {
        return (value & AccessMode.Readable) != 0;
    }

    public static bool IsWriteable(this AccessMode value)
    {
        return (value & AccessMode.Writeable) != 0;
    }

    public static bool IsWriteOnly(this AccessMode value)
    {
        return value == AccessMode.Writeable;
    }

    public static bool IsReadOnly(this AccessMode value)
    {
        return value == AccessMode.Readable;
    }
}