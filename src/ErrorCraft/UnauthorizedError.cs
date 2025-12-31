namespace ErrorCraft;

/// <summary>
/// A specialized error for when a request lacks valid authentication credentials.
/// </summary>
public record UnauthorizedError : IUnauthorizedError
{
    /// <inheritdoc />
    public required string Code { get; init; }

    /// <inheritdoc />
    public required string Message { get; init; }

    /// <inheritdoc />
    public ErrorSeverity Severity { get; init; }

    /// <inheritdoc />
    public IReadOnlyDictionary<string, object>? Metadata { get; init; }
}
