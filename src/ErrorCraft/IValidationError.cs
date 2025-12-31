namespace ErrorCraft;

/// <summary>
/// Represents a validation failure, typically for a specific property.
/// </summary>
public interface IValidationError : IError, IProblemDetailsSource
{
    int IProblemDetailsSource.Status => 400;
    string IProblemDetailsSource.Title => "Bad Request";
    string IProblemDetailsSource.Type => "https://tools.ietf.org/html/rfc9110#section-15.5.1";

    /// <summary>
    /// Specifies the full path of the target property or field where the validation error occurred,
    /// allowing precise identification of the location in complex object graphs.
    /// </summary>
    public string TargetPath { get; }
    
    /// <summary>
    /// The name of the target that failed validation.
    /// </summary>
    string TargetName { get; }

    /// <summary>
    /// The value of the property that was attempted.
    /// </summary>
    object? AttemptedValue { get; }
}