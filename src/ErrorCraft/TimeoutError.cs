namespace ErrorCraft;

/// <summary>
/// A specialized error for when an operation times out.
/// </summary>
public record TimeoutError : ITimeoutError
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
    public TimeSpan? Timeout { get; init; }
}
