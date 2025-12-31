namespace ErrorCraft;

/// <summary>
/// A generic, type-safe representation of a bad request error.
/// </summary>
public record BadRequestError : IBadRequestError
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
