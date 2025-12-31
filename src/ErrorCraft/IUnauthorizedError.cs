namespace ErrorCraft;

/// <summary>
/// Represents an error that occurs when a request lacks valid authentication credentials.
/// </summary>
public interface IUnauthorizedError : IError, IProblemDetailsSource
{
    int IProblemDetailsSource.Status => 401;
    string IProblemDetailsSource.Title => "Unauthorized";
    string IProblemDetailsSource.Type => "https://tools.ietf.org/html/rfc9110#section-15.5.2";
}
