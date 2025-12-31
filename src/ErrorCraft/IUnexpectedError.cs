namespace ErrorCraft;

/// <summary>
/// Represents an unexpected error that occurred within the system.
/// </summary>
public interface IUnexpectedError : IError, IProblemDetailsSource
{
    int IProblemDetailsSource.Status => 500;
    string IProblemDetailsSource.Title => "Internal Server Error";
    string IProblemDetailsSource.Type => "https://tools.ietf.org/html/rfc9110#section-15.6.1";

    /// <summary>
    /// Gets the exception that caused the unexpected error, if available.
    /// </summary>
    Exception? Exception { get; }
}
