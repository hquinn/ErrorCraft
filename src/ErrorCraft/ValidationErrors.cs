namespace ErrorCraft;

/// <summary>
/// A representation of multiple validation failures.
/// </summary>
public record ValidationErrors : IValidationErrors
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
    public required IReadOnlyCollection<IValidationError> Errors { get; init; }
}
