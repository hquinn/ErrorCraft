namespace ErrorCraft;

/// <summary>
/// A specialized error for when a request conflicts with the current state of the server.
/// </summary>
public record ConflictError : IConflictError
{
    /// <inheritdoc />
    public required string Code { get; init; }

    /// <inheritdoc />
    public required string Message { get; init; }

    /// <inheritdoc />
    public ErrorSeverity Severity { get; init; }

    /// <inheritdoc />
    public IReadOnlyDictionary<string, object?>? Metadata { get; init; }
}
