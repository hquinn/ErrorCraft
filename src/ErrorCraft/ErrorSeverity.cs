namespace ErrorCraft;

/// <summary>
/// Defines the severity level of an error.
/// </summary>
/// <remarks>
/// Use severity levels to categorize failures and implement
/// different handling strategies based on error importance.
/// </remarks>
public enum ErrorSeverity
{
    /// <summary>
    /// Informational message that does not necessarily indicate a problem.
    /// </summary>
    Info,

    /// <summary>
    /// Warning that indicates a potential issue.
    /// </summary>
    Warning,

    /// <summary>
    /// Error that indicates a failure that should be addressed.
    /// </summary>
    Error,

    /// <summary>
    /// Indicates a critical level of severity, representing a severe error
    /// condition that typically requires immediate attention or intervention.
    /// </summary>
    Critical
}