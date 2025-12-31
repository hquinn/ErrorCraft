namespace ErrorCraft;

/// <summary>
/// Represents a generic bad request error.
/// </summary>
public interface IBadRequestError : IError, IProblemDetailsSource
{
    int IProblemDetailsSource.Status => 400;
    string IProblemDetailsSource.Title => "Bad Request";
    string IProblemDetailsSource.Type => "https://tools.ietf.org/html/rfc9110#section-15.5.1";
}
