namespace ErrorCraft;

/// <summary>
/// Represents an error that occurs when a request conflicts with the current state of the server.
/// </summary>
public interface IConflictError : IError, IProblemDetailsSource
{
    int IProblemDetailsSource.Status => 409;
    string IProblemDetailsSource.Title => "Conflict";
    string IProblemDetailsSource.Type => "https://tools.ietf.org/html/rfc9110#section-15.5.10";
}
