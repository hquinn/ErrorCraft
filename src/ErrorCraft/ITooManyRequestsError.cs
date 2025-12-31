namespace ErrorCraft;

/// <summary>
/// Represents an error that occurs when the user has sent too many requests in a given amount of time.
/// </summary>
public interface ITooManyRequestsError : IError, IProblemDetailsSource
{
    int IProblemDetailsSource.Status => 429;
    string IProblemDetailsSource.Title => "Too Many Requests";
    string IProblemDetailsSource.Type => "https://tools.ietf.org/html/rfc6585#section-4";

    /// <summary>
    /// The estimated duration until the user can retry the request, if known.
    /// </summary>
    TimeSpan? RetryAfter { get; }
}
