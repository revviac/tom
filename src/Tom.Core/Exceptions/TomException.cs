namespace Tom.Core.Exceptions;

/// <summary>
///     Base class for all TOM exceptions
/// </summary>
public class TomException : Exception
{
    public TomException() : base() { }

    public TomException(string message) : base() { }

    public TomException(string message, Exception innerException) : base() { }
}