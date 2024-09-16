using System.Text.Json.Serialization;

namespace FastProjects.ResultPattern;

/// <summary>
/// Represents the result of an operation with a value of type <typeparamref name="T"/>.
/// </summary>
/// <typeparam name="T">The type of the value contained in the result.</typeparam>
public class Result<T> : IResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Result{T}"/> class.
    /// </summary>
    protected Result() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="Result{T}"/> class with a specified value.
    /// </summary>
    /// <param name="value">The value contained in the result.</param>
    public Result(T value) => Value = value;

    /// <summary>
    /// Initializes a new instance of the <see cref="Result{T}"/> class with specified status, value, errors, and validation errors.
    /// </summary>
    /// <param name="status">The status of the result.</param>
    /// <param name="value">The value contained in the result.</param>
    /// <param name="errors">The collection of error messages.</param>
    /// <param name="validationErrors">The collection of validation errors.</param>
    protected internal Result(
        ResultStatus status,
        T? value = default,
        IEnumerable<string>? errors = null,
        IEnumerable<ValidationError>? validationErrors = null)
    {
        Value = value;
        Status = status;
        Errors = errors ?? [];
        ValidationErrors = validationErrors ?? [];
    }

    /// <summary>
    /// Gets the value contained in the result.
    /// </summary>
    [JsonInclude]
    public T? Value { get; private init; }

    /// <inheritdoc/>
    [JsonInclude]
    public ResultStatus Status { get; private init; }

    /// <inheritdoc/>
    [JsonInclude]
    public IEnumerable<string> Errors { get; private init; }

    /// <inheritdoc/>
    [JsonInclude]
    public IEnumerable<ValidationError> ValidationErrors { get; private init; }

    /// <inheritdoc/>
    [JsonIgnore]
    public Type ValueType => typeof(T);

    /// <inheritdoc/>
    public object? GetValue() => Value;

    /// <summary>
    /// Gets a value indicating whether the result is successful.
    /// </summary>
    public bool IsSuccess => this.IsOk() || this.IsCreated() || this.IsNoContent();

    /// <summary>
    /// Implicitly converts a <see cref="Result{T}"/> to its value of type <typeparamref name="T"/>.
    /// </summary>
    /// <param name="result">The result to convert.</param>
    public static implicit operator T(Result<T> result) => result.Value;

    /// <summary>
    /// Implicitly converts a value of type <typeparamref name="T"/> to a <see cref="Result{T}"/>.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    public static implicit operator Result<T>(T value) => new Result<T>(value);

    /// <summary>
    /// Implicitly converts a <see cref="Result"/> to a <see cref="Result{T}"/>.
    /// </summary>
    /// <param name="result">The result to convert.</param>
    public static implicit operator Result<T>(Result result) => new Result<T>(default(T)!)
    {
        Status = result.Status,
        Errors = result.Errors,
        ValidationErrors = result.ValidationErrors,
    };

    /// <summary>
    /// Creates a successful result with a specified value.
    /// </summary>
    /// <param name="value">The value contained in the result.</param>
    /// <returns>A successful result.</returns>
    public static Result<T> Success(T value) =>
        new(ResultStatus.Ok, value);

    /// <summary>
    /// Creates an error result with specified error messages.
    /// </summary>
    /// <param name="errorMessages">The error messages.</param>
    /// <returns>An error result.</returns>
    public static Result<T> Error(params string[] errorMessages) =>
        new(ResultStatus.Error, errors: errorMessages);

    /// <summary>
    /// Creates an invalid result with specified validation errors.
    /// </summary>
    /// <param name="validationErrors">The validation errors.</param>
    /// <returns>An invalid result.</returns>
    public static Result<T> Invalid(params ValidationError[] validationErrors) =>
        new(ResultStatus.Invalid, validationErrors: validationErrors);

    /// <summary>
    /// Creates a not found result with specified error messages.
    /// </summary>
    /// <param name="errorMessages">The error messages.</param>
    /// <returns>A not found result.</returns>
    public static Result<T> NotFound(params string[] errorMessages) =>
        new(ResultStatus.NotFound, errors: errorMessages);

    /// <summary>
    /// Creates a forbidden result with specified error messages.
    /// </summary>
    /// <param name="errorMessages">The error messages.</param>
    /// <returns>A forbidden result.</returns>
    public static Result<T> Forbidden(params string[] errorMessages) =>
        new(ResultStatus.Forbidden, errors: errorMessages);

    /// <summary>
    /// Creates an unauthorized result with specified error messages.
    /// </summary>
    /// <param name="errorMessages">The error messages.</param>
    /// <returns>An unauthorized result.</returns>
    public static Result<T> Unauthorized(params string[] errorMessages) =>
        new(ResultStatus.Unauthorized, errors: errorMessages);

    /// <summary>
    /// Creates a conflict result with specified error messages.
    /// </summary>
    /// <param name="errorMessages">The error messages.</param>
    /// <returns>A conflict result.</returns>
    public static Result<T> Conflict(params string[] errorMessages) =>
        new(ResultStatus.Conflict, errors: errorMessages);

    /// <summary>
    /// Creates a critical error result with specified error messages.
    /// </summary>
    /// <param name="errorMessages">The error messages.</param>
    /// <returns>A critical error result.</returns>
    public static Result<T> CriticalError(params string[] errorMessages) =>
        new(ResultStatus.CriticalError, errors: errorMessages);

    /// <summary>
    /// Creates a created result.
    /// </summary>
    /// <returns>A created result.</returns>
    public static Result<T> Created() =>
        new(ResultStatus.Created);

    /// <summary>
    /// Creates a no content result.
    /// </summary>
    /// <returns>A no content result.</returns>
    public static Result<T> NoContent() =>
        new(ResultStatus.NoContent);

    /// <summary>
    /// Creates an unavailable result.
    /// </summary>
    /// <returns>An unavailable result.</returns>
    public static Result<T> Unavailable() =>
        new(ResultStatus.Unavailable);
}

/// <summary>
/// Represents the result of an operation without a value.
/// </summary>
public class Result : Result<Result>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Result"/> class.
    /// </summary>
    protected Result() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="Result"/> class with specified status, value, errors, and validation errors.
    /// </summary>
    /// <param name="status">The status of the result.</param>
    /// <param name="value">The value contained in the result.</param>
    /// <param name="errors">The collection of error messages.</param>
    /// <param name="validationErrors">The collection of validation errors.</param>
    protected internal Result(
        ResultStatus status,
        Result? value = default,
        IEnumerable<string>? errors = null,
        IEnumerable<ValidationError>? validationErrors = null)
        : base(status, value, errors, validationErrors)
    {
    }

    /// <summary>
    /// Creates a successful result.
    /// </summary>
    /// <returns>A successful result.</returns>
    public static Result Success() =>
        new(ResultStatus.Ok);

    /// <summary>
    /// Creates a successful result with a specified value.
    /// </summary>
    /// <typeparam name="T">The type of the value contained in the result.</typeparam>
    /// <returns>A successful result.</returns>
    public static Result Success<T>() =>
        new(ResultStatus.Ok);

    /// <summary>
    /// Creates a successful result with a specified value.
    /// </summary>
    /// <typeparam name="T">The type of the value contained in the result.</typeparam>
    /// <param name="value">The value contained in the result.</param>
    /// <returns>A successful result.</returns>
    public static Result<T> Success<T>(T value) =>
        new(value);

    /// <summary>
    /// Creates an error result with specified error messages.
    /// </summary>
    /// <param name="errorMessages">The error messages.</param>
    /// <returns>An error result.</returns>
    public static new Result Error(params string[] errorMessages) =>
        new(ResultStatus.Error, errors: errorMessages);

    /// <summary>
    /// Creates an invalid result with specified validation errors.
    /// </summary>
    /// <param name="validationErrors">The validation errors.</param>
    /// <returns>An invalid result.</returns>
    public static new Result Invalid(params ValidationError[] validationErrors) =>
        new(ResultStatus.Invalid, validationErrors: validationErrors);

    /// <summary>
    /// Creates a not found result with specified error messages.
    /// </summary>
    /// <param name="errorMessages">The error messages.</param>
    /// <returns>A not found result.</returns>
    public static new Result NotFound(params string[] errorMessages) =>
        new(ResultStatus.NotFound, errors: errorMessages);

    /// <summary>
    /// Creates a forbidden result with specified error messages.
    /// </summary>
    /// <param name="errorMessages">The error messages.</param>
    /// <returns>A forbidden result.</returns>
    public static new Result Forbidden(params string[] errorMessages) =>
        new(ResultStatus.Forbidden, errors: errorMessages);

    /// <summary>
    /// Creates an unauthorized result with specified error messages.
    /// </summary>
    /// <param name="errorMessages">The error messages.</param>
    /// <returns>An unauthorized result.</returns>
    public static new Result Unauthorized(params string[] errorMessages) =>
        new(ResultStatus.Unauthorized, errors: errorMessages);

    /// <summary>
    /// Creates a conflict result with specified error messages.
    /// </summary>
    /// <param name="errorMessages">The error messages.</param>
    /// <returns>A conflict result.</returns>
    public static new Result Conflict(params string[] errorMessages) =>
        new(ResultStatus.Conflict, errors: errorMessages);

    /// <summary>
    /// Creates a critical error result with specified error messages.
    /// </summary>
    /// <param name="errorMessages">The error messages.</param>
    /// <returns>A critical error result.</returns>
    public static new Result CriticalError(params string[] errorMessages) =>
        new(ResultStatus.CriticalError, errors: errorMessages);

    /// <summary>
    /// Creates a created result.
    /// </summary>
    /// <returns>A created result.</returns>
    public static new Result Created() =>
        new(ResultStatus.Created);

    /// <summary>
    /// Creates a created result with a specified value.
    /// </summary>
    /// <typeparam name="T">The type of the value contained in the result.</typeparam>
    /// <param name="value">The value contained in the result.</param>
    /// <returns>A created result.</returns>
    public static Result<T> Created<T>(T value) =>
        new(ResultStatus.Created, value);

    /// <summary>
    /// Creates a no content result.
    /// </summary>
    /// <returns>A no content result.</returns>
    public static new Result NoContent() =>
        new(ResultStatus.NoContent);

    /// <summary>
    /// Creates an unavailable result.
    /// </summary>
    /// <returns>An unavailable result.</returns>
    public static new Result Unavailable() =>
        new(ResultStatus.Unavailable);
}
