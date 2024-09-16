namespace FastProjects.ResultPattern;

/// <summary>
/// Defines the possible statuses for a result.
/// </summary>
public enum ResultStatus
{
    /// <summary>
    /// Indicates a successful operation.
    /// </summary>
    Ok,

    /// <summary>
    /// Indicates that a resource was successfully created.
    /// </summary>
    Created,

    /// <summary>
    /// Indicates an error occurred during the operation.
    /// </summary>
    Error,

    /// <summary>
    /// Indicates that access to the resource is forbidden.
    /// </summary>
    Forbidden,

    /// <summary>
    /// Indicates that the user is not authorized to access the resource.
    /// </summary>
    Unauthorized,

    /// <summary>
    /// Indicates that the request is invalid.
    /// </summary>
    Invalid,

    /// <summary>
    /// Indicates that the resource was not found.
    /// </summary>
    NotFound,

    /// <summary>
    /// Indicates that there is no content to return.
    /// </summary>
    NoContent,

    /// <summary>
    /// Indicates a conflict occurred during the operation.
    /// </summary>
    Conflict,

    /// <summary>
    /// Indicates a critical error occurred during the operation.
    /// </summary>
    CriticalError,

    /// <summary>
    /// Indicates that the service is unavailable.
    /// </summary>
    Unavailable
}
