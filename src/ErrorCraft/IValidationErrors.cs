namespace ErrorCraft;

/// <summary>
/// Represents a collection of validation failures.
/// </summary>
public interface IValidationErrors : IError, IProblemDetailsSource
{
    int IProblemDetailsSource.Status => 400;
    string IProblemDetailsSource.Title => "One or more validation errors occurred.";
    string IProblemDetailsSource.Type => "https://tools.ietf.org/html/rfc9110#section-15.5.1";

    /// <summary>
    /// The collection of validation errors.
    /// </summary>
    IReadOnlyCollection<IValidationError> Errors { get; }
}
