namespace FastProjects.ResultPattern;

/// <summary>
/// Represents a validation error.
/// </summary>
public class ValidationError
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ValidationError"/> class.
    /// </summary>
    public ValidationError() { }
    
    /// <summary>
    /// Initializes a new instance of the <see cref="ValidationError"/> class with a specified error message.
    /// </summary>
    /// <param name="errorMessage">The error message.</param>
    public ValidationError(string errorMessage) => ErrorMessage = errorMessage;

    /// <summary>
    /// Initializes a new instance of the <see cref="ValidationError"/> class with specified identifier, error message, error code, and severity.
    /// </summary>
    /// <param name="identifier">The identifier of the validation error.</param>
    /// <param name="errorMessage">The error message.</param>
    /// <param name="errorCode">The error code.</param>
    /// <param name="severity">The severity of the validation error.</param>
    public ValidationError(string identifier, string errorMessage, string errorCode, ValidationSeverity severity)
    {
        Identifier = identifier;
        ErrorMessage = errorMessage;
        ErrorCode = errorCode;
        Severity = severity;
    }

    /// <summary>
    /// Gets the identifier of the validation error.
    /// </summary>
    public string Identifier { get; init; }

    /// <summary>
    /// Gets the error message.
    /// </summary>
    public string ErrorMessage { get; init; }

    /// <summary>
    /// Gets the error code.
    /// </summary>
    public string ErrorCode { get; init; }

    /// <summary>
    /// Gets the severity of the validation error.
    /// </summary>
    public ValidationSeverity Severity { get; init; } = ValidationSeverity.Error;
}
