namespace FastProjects.ResultPattern;

/// <summary>
/// Represents the result of an operation.
/// </summary>
public interface IResult
{
    /// <summary>
    /// Gets the status of the result.
    /// </summary>
    ResultStatus Status { get; }

    /// <summary>
    /// Gets the collection of error messages.
    /// </summary>
    IEnumerable<string> Errors { get; }

    /// <summary>
    /// Gets the collection of validation errors.
    /// </summary>
    IEnumerable<ValidationError> ValidationErrors { get; }

    /// <summary>
    /// Gets the type of the value contained in the result.
    /// </summary>
    Type ValueType { get; }

    /// <summary>
    /// Gets the value contained in the result.
    /// </summary>
    /// <returns>The value contained in the result, or null if there is no value.</returns>
    object? GetValue();
}
