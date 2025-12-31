namespace ErrorCraft;

/// <summary>
/// A specialized error for when a service or dependency is unavailable.
/// </summary>
public record ServiceUnavailableError : IServiceUnavailableError
{
    /// <inheritdoc />
    public required string Code { get; init; }

    /// <inheritdoc />
    public required string Message { get; init; }

    /// <inheritdoc />
    public ErrorSeverity Severity { get; init; }

    /// <inheritdoc />
    public IReadOnlyDictionary<string, object?>? Metadata { get; init; }

    /// <inheritdoc />
    public string? ServiceName { get; init; }

    /// <inheritdoc />
    public TimeSpan? RetryAfter { get; init; }
}
