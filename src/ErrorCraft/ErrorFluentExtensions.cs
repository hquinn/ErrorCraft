namespace ErrorCraft;

/// <summary>
/// Provides fluent extension methods for <see cref="IError"/>.
/// </summary>
public static class ErrorFluentExtensions
{
    /// <summary>
    /// Adds or updates metadata on the error.
    /// </summary>
    /// <typeparam name="T">The type of the error.</typeparam>
    /// <param name="error">The error to update.</param>
    /// <param name="key">The metadata key.</param>
    /// <param name="value">The metadata value.</param>
    /// <returns>A new instance of the error with the updated metadata.</returns>
    public static T WithMetadata<T>(this T error, string key, object value) where T : IError
    {
        var newMetadata = error.Metadata != null
            ? new Dictionary<string, object>(error.Metadata)
            : new Dictionary<string, object>();

        newMetadata[key] = value;

        return error switch
        {
            Error e => (T)(object)(e with { Metadata = newMetadata }),
            BadRequestError br => (T)(object)(br with { Metadata = newMetadata }),
            UnauthorizedError u => (T)(object)(u with { Metadata = newMetadata }),
            ForbiddenError f => (T)(object)(f with { Metadata = newMetadata }),
            ConflictError c => (T)(object)(c with { Metadata = newMetadata }),
            UnprocessableEntityError ue => (T)(object)(ue with { Metadata = newMetadata }),
            UnexpectedError un => (T)(object)(un with { Metadata = newMetadata }),
            TooManyRequestsError tm => (T)(object)(tm with { Metadata = newMetadata }),
            ServiceUnavailableError s => (T)(object)(s with { Metadata = newMetadata }),
            TimeoutError t => (T)(object)(t with { Metadata = newMetadata }),
            _ => HandleRecords(error, newMetadata, null)
        };
    }

    /// <summary>
    /// Sets the severity of the error.
    /// </summary>
    /// <typeparam name="T">The type of the error.</typeparam>
    /// <param name="error">The error to update.</param>
    /// <param name="severity">The new severity level.</param>
    /// <returns>A new instance of the error with the updated severity.</returns>
    public static T WithSeverity<T>(this T error, ErrorSeverity severity) where T : IError
    {
        return error switch
        {
            Error e => (T)(object)(e with { Severity = severity }),
            BadRequestError br => (T)(object)(br with { Severity = severity }),
            UnauthorizedError u => (T)(object)(u with { Severity = severity }),
            ForbiddenError f => (T)(object)(f with { Severity = severity }),
            ConflictError c => (T)(object)(c with { Severity = severity }),
            UnprocessableEntityError ue => (T)(object)(ue with { Severity = severity }),
            UnexpectedError un => (T)(object)(un with { Severity = severity }),
            TooManyRequestsError tm => (T)(object)(tm with { Severity = severity }),
            ServiceUnavailableError s => (T)(object)(s with { Severity = severity }),
            TimeoutError t => (T)(object)(t with { Severity = severity }),
            _ => HandleRecords(error, null, severity)
        };
    }

    private static T HandleRecords<T>(T error, Dictionary<string, object>? metadata, ErrorSeverity? severity) where T : IError
    {
        // Handle generic records like ValidationError<T> and NotFoundError<T> using reflection
        // to avoid invariance issues with switch expressions and to keep the API clean.
        var type = error.GetType();
        
        // Records in C# have a copy constructor: protected Record(Record other)
        // and 'with' expressions use it.
        var copy = (T)Activator.CreateInstance(type, error)!;

        // Use reflection to set the properties since they are 'init' only but we can set them on a new instance
        if (metadata != null)
        {
            type.GetProperty(nameof(IError.Metadata))?.SetValue(copy, metadata);
        }
        if (severity.HasValue)
        {
            type.GetProperty(nameof(IError.Severity))?.SetValue(copy, severity.Value);
        }
        return copy;
    }
}
