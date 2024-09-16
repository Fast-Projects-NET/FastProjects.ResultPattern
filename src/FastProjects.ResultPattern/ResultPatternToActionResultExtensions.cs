using Microsoft.AspNetCore.Http;

namespace FastProjects.ResultPattern;

/// <summary>
/// Provides extension methods for converting result patterns to web results.
/// </summary>
public static class ResultPatternToActionResultExtensions
{
    /// <summary>
    /// Converts a <see cref="ResultPattern.Result"/> to an <see cref="Microsoft.AspNetCore.Http.IResult"/>.
    /// </summary>
    /// <param name="result">The result to convert.</param>
    /// <returns>The corresponding <see cref="Microsoft.AspNetCore.Http.IResult"/>.</returns>
    public static Microsoft.AspNetCore.Http.IResult ToWebResult(this Result result) =>
        GenerateIResult(result.Status, result.Errors);

    /// <summary>
    /// Converts a <see cref="Result{T}"/> to an <see cref="Microsoft.AspNetCore.Http.IResult"/>.
    /// </summary>
    /// <typeparam name="T">The type of the value contained in the result.</typeparam>
    /// <param name="result">The result to convert.</param>
    /// <returns>The corresponding <see cref="Microsoft.AspNetCore.Http.IResult"/>.</returns>
    public static Microsoft.AspNetCore.Http.IResult ToWebResult<T>(this Result<T> result) =>
        GenerateIResult(result.Status, result.Errors);

    /// <summary>
    /// Generates an <see cref="Microsoft.AspNetCore.Http.IResult"/> based on the result status and errors.
    /// </summary>
    /// <param name="resultStatus">The status of the result.</param>
    /// <param name="resultErrors">The collection of error messages.</param>
    /// <returns>The corresponding <see cref="Microsoft.AspNetCore.Http.IResult"/>.</returns>
    /// <exception cref="InvalidOperationException">Thrown when the result status is successful.</exception>
    private static Microsoft.AspNetCore.Http.IResult GenerateIResult(ResultStatus resultStatus, IEnumerable<string> resultErrors)
    {
        Dictionary<string, object?> errors = new()
        {
            { "errors", resultErrors.ToArray() }
        };

        return resultStatus switch
        {
            ResultStatus.Created or ResultStatus.NoContent or ResultStatus.Ok =>
                throw new InvalidOperationException("Cannot convert successful result to IResult"),

            ResultStatus.NotFound => Results.Problem(
                statusCode: StatusCodes.Status404NotFound,
                title: "Resource not found",
                extensions: errors),

            ResultStatus.Forbidden => Results.Problem(
                statusCode: StatusCodes.Status403Forbidden,
                title: "Access denied",
                extensions: errors),

            ResultStatus.Unauthorized => Results.Problem(
                statusCode: StatusCodes.Status401Unauthorized,
                title: "Unauthorized",
                extensions: errors),

            ResultStatus.Invalid => Results.Problem(
                statusCode: StatusCodes.Status400BadRequest,
                title: "Invalid request",
                extensions: errors),

            ResultStatus.Conflict => Results.Problem(
                statusCode: StatusCodes.Status409Conflict,
                title: "Conflict",
                extensions: errors),

            ResultStatus.CriticalError => Results.Problem(
                statusCode: StatusCodes.Status500InternalServerError,
                title: "An unexpected error occurred",
                extensions: errors),

            ResultStatus.Unavailable => Results.Problem(
                statusCode: StatusCodes.Status503ServiceUnavailable,
                title: "Service unavailable",
                extensions: errors),

            ResultStatus.Error => Results.Problem(
                statusCode: StatusCodes.Status400BadRequest,
                title: "An unexpected error occurred",
                extensions: errors),

            _ => throw new InvalidOperationException("Unhandled result status")
        };
    }
}
