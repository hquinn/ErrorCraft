namespace ErrorCraft;

/// <summary>
/// A specialized error for when a request is well-formed but cannot be processed due to semantic errors.
/// </summary>
public record UnprocessableEntityError : IUnprocessableEntityError
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
