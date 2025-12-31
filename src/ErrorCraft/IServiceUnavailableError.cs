namespace ErrorCraft;

/// <summary>
/// Represents an error that occurs when a service or dependency is unavailable.
/// </summary>
public interface IServiceUnavailableError : IError, IProblemDetailsSource
{
    int IProblemDetailsSource.Status => 503;
    string IProblemDetailsSource.Title => "Service Unavailable";
    string IProblemDetailsSource.Type => "https://tools.ietf.org/html/rfc9110#section-15.6.4";

    /// <summary>
    /// The name of the service that is unavailable.
    /// </summary>
    string? ServiceName { get; }

    /// <summary>
    /// The estimated duration until the service becomes available again, if known.
    /// </summary>
    TimeSpan? RetryAfter { get; }
}
