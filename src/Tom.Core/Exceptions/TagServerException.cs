namespace Tom.Core.Exceptions;

/// <summary>
///     Exception that should be raised if an error has occurred during the communication with the tag server
/// </summary>
public class TagServerException : TomException
{
    public TagServerException() : base() { }

    public TagServerException(string message) : base(message) { }

    public TagServerException(string message, Exception innerException) : base(message, innerException) { }
}