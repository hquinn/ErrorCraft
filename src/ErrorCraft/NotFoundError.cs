namespace ErrorCraft;

/// <summary>
/// A specialized error for when a requested resource is not found.
/// </summary>
/// <typeparam name="TKey">The type of the resource identifier.</typeparam>
public record NotFoundError<TKey> : INotFoundError
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
    public required string ResourceType { get; init; }

    /// <summary>
    /// Gets the identifier of the resource that was not found.
    /// </summary>
    public required TKey ResourceId { get; init; }

    /// <inheritdoc />
    object? INotFoundError.ResourceId => this.ResourceId;
}
