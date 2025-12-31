namespace ErrorCraft;

/// <summary>
/// Represents an error that occurs when an operation times out.
/// </summary>
public interface ITimeoutError : IError, IProblemDetailsSource
{
    int IProblemDetailsSource.Status => 504;
    string IProblemDetailsSource.Title => "Gateway Timeout";
    string IProblemDetailsSource.Type => "https://tools.ietf.org/html/rfc9110#section-15.6.5";

    /// <summary>
    /// The duration of the timeout that was exceeded.
    /// </summary>
    TimeSpan? Timeout { get; }
}
