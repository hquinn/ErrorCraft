namespace ErrorCraft;

/// <summary>
/// Represents an error where the request was well-formed but was unable to be followed due to semantic errors.
/// </summary>
public interface IUnprocessableEntityError : IError, IProblemDetailsSource
{
    int IProblemDetailsSource.Status => 422;
    string IProblemDetailsSource.Title => "Unprocessable Entity";
    string IProblemDetailsSource.Type => "https://tools.ietf.org/html/rfc4918#section-11.2";
}
