namespace ErrorCraft;

/// <summary>
/// A specialized error for when the user has sent too many requests.
/// </summary>
public record TooManyRequestsError : ITooManyRequestsError
{
    /// <inheritdoc />
    public required string Code { get; init; }

    /// <inheritdoc />
    public required string Message { get; init; }

    /// <inheritdoc />
    public ErrorSeverity Severity { get; init; }

    /// <inheritdoc />
    public IReadOnlyDictionary<string, object>? Metadata { get; init; }

    /// <inheritdoc />
    public TimeSpan? RetryAfter { get; init; }
}
