namespace ErrorCraft;

/// <summary>
/// A generic, type-safe representation of an error.
/// </summary>
public record Error : IError
{
    /// <inheritdoc />
    public required string Code { get; init; }

    /// <inheritdoc />
    public required string Message { get; init; }

    /// <inheritdoc />
    public ErrorSeverity Severity { get; init; }

    /// <inheritdoc />
    public IReadOnlyDictionary<string, object?>? Metadata { get; init; }

    /// <summary>
    /// Creates a new <see cref="BadRequestError"/> instance.
    /// </summary>
    public static BadRequestError BadRequest(string code, string message) => new()
    {
        Code = code,
        Message = message,
        Severity = ErrorSeverity.Error
    };

    /// <summary>
    /// Creates a new <see cref="ValidationError{TTarget}"/> instance.
    /// </summary>
    public static ValidationError<TTarget> Validation<TTarget>(
        string code,
        string message,
        string targetName,
        string targetPath,
        TTarget attemptedValue) => new()
    {
        Code = code,
        Message = message,
        TargetName = targetName,
        TargetPath = targetPath,
        AttemptedValue = attemptedValue,
        Severity = ErrorSeverity.Error
    };

    /// <summary>
    /// Creates a new <see cref="NotFoundError{TKey}"/> instance.
    /// </summary>
    public static NotFoundError<TKey> NotFound<TKey>(
        string code,
        string message,
        string resourceType,
        TKey resourceId) => new()
    {
        Code = code,
        Message = message,
        ResourceType = resourceType,
        ResourceId = resourceId,
        Severity = ErrorSeverity.Error
    };

    /// <summary>
    /// Creates a new <see cref="UnauthorizedError"/> instance.
    /// </summary>
    public static UnauthorizedError Unauthorized(string code, string message) => new()
    {
        Code = code,
        Message = message,
        Severity = ErrorSeverity.Error
    };

    /// <summary>
    /// Creates a new <see cref="ForbiddenError"/> instance.
    /// </summary>
    public static ForbiddenError Forbidden(string code, string message) => new()
    {
        Code = code,
        Message = message,
        Severity = ErrorSeverity.Error
    };

    /// <summary>
    /// Creates a new <see cref="ConflictError"/> instance.
    /// </summary>
    public static ConflictError Conflict(string code, string message) => new()
    {
        Code = code,
        Message = message,
        Severity = ErrorSeverity.Error
    };

    /// <summary>
    /// Creates a new <see cref="UnprocessableEntityError"/> instance.
    /// </summary>
    public static UnprocessableEntityError UnprocessableEntity(string code, string message) => new()
    {
        Code = code,
        Message = message,
        Severity = ErrorSeverity.Error
    };

    /// <summary>
    /// Creates a new <see cref="TooManyRequestsError"/> instance.
    /// </summary>
    public static TooManyRequestsError TooManyRequests(
        string code,
        string message,
        TimeSpan? retryAfter = null) => new()
    {
        Code = code,
        Message = message,
        RetryAfter = retryAfter,
        Severity = ErrorSeverity.Error
    };

    /// <summary>
    /// Creates a new <see cref="ServiceUnavailableError"/> instance.
    /// </summary>
    public static ServiceUnavailableError ServiceUnavailable(
        string code,
        string message,
        string? serviceName = null,
        TimeSpan? retryAfter = null) => new()
    {
        Code = code,
        Message = message,
        ServiceName = serviceName,
        RetryAfter = retryAfter,
        Severity = ErrorSeverity.Error
    };

    /// <summary>
    /// Creates a new <see cref="TimeoutError"/> instance.
    /// </summary>
    public static TimeoutError Timeout(
        string code,
        string message,
        TimeSpan? timeout = null) => new()
    {
        Code = code,
        Message = message,
        Timeout = timeout,
        Severity = ErrorSeverity.Error
    };

    /// <summary>
    /// Creates a new <see cref="UnexpectedError"/> instance.
    /// </summary>
    public static UnexpectedError Unexpected(string code, string message, Exception? exception = null) => new()
    {
        Code = code,
        Message = message,
        Exception = exception,
        Severity = ErrorSeverity.Critical
    };
}
