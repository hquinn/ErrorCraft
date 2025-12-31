namespace ErrorCraft;

/// <summary>
/// Represents an error that occurs when a requested resource is not found.
/// </summary>
public interface INotFoundError : IError, IProblemDetailsSource
{
    int IProblemDetailsSource.Status => 404;
    string IProblemDetailsSource.Title => "Resource Not Found";
    string IProblemDetailsSource.Type => "https://tools.ietf.org/html/rfc9110#section-15.5.5";

    /// <summary>
    /// The type of the resource that was not found.
    /// </summary>
    string ResourceType { get; }

    /// <summary>
    /// The identifier of the resource that was not found.
    /// </summary>
    object? ResourceId { get; }
}
