namespace ErrorCraft;

/// <summary>
/// Represents an error
/// </summary>
public interface IError
{
    /// <summary>
    /// A unique identifier for the specific error, typically used to categorize or look up error details.
    /// </summary>
    public string Code { get; }

    /// <summary>
    /// Describes the details of the failure, providing human-readable
    /// information about what went wrong or the reason for the error.
    /// </summary>
    public string Message { get; }

    /// <summary>
    /// Indicates the severity level of the error,
    /// specifying whether the issue is critical, an error, a warning, or informational.
    /// </summary>
    public ErrorSeverity Severity { get; }

    /// <summary>
    /// Optional metadata associated with the error.
    /// </summary>
    IReadOnlyDictionary<string, object?>? Metadata { get; }
}