namespace ErrorCraft;

/// <summary>
/// A specialized error for when a user is authenticated but does not have permission to access a resource.
/// </summary>
public record ForbiddenError : IForbiddenError
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
