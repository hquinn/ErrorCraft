namespace ErrorCraft;

/// <summary>
/// Represents an error that occurs when a user is authenticated but does not have permission to access a resource.
/// </summary>
public interface IForbiddenError : IError, IProblemDetailsSource
{
    int IProblemDetailsSource.Status => 403;
    string IProblemDetailsSource.Title => "Forbidden";
    string IProblemDetailsSource.Type => "https://tools.ietf.org/html/rfc9110#section-15.5.4";
}
