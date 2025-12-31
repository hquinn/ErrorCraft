using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ErrorCraft.AspNet;

/// <summary>
/// Provides extension methods for mapping <see cref="IError"/> to ASP.NET Core types.
/// </summary>
public static class ErrorExtensions
{
    /// <summary>
    /// Converts an <see cref="IError"/> to a <see cref="ProblemDetails"/> object.
    /// </summary>
    /// <param name="error">The error to convert.</param>
    /// <param name="context">The <see cref="HttpContext"/> to extract the trace identifier from.</param>
    /// <param name="includeDetails">The parameter which determines whether to include exception details.
    /// Only set this to true in development environments.</param>
    /// <returns>A <see cref="ProblemDetails"/> representation of the error.</returns>
    public static ProblemDetails ToProblemDetails(
        this IError error,
        HttpContext context,
        bool includeDetails = false)
    {
        var (status, title, type, extensions) = PrepareProblemDetails(error, context, includeDetails);

        return new ProblemDetails
        {
            Status = status,
            Title = title,
            Detail = error.Message,
            Type = type,
            Instance = context.Request.Path,
            Extensions = extensions
        };
    }

    /// <summary>
    /// Converts an <see cref="IError"/> to an <see cref="IResult"/> representing a problem.
    /// </summary>
    /// <param name="error">The error to convert.</param>
    /// <param name="context">The <see cref="HttpContext"/> to extract the trace identifier from.</param>
    /// <param name="includeDetails">The parameter which determines whether to include exception details.
    /// Only set this to true in development environments.</param>
    /// <returns>An <see cref="IResult"/> representing the error as a problem.</returns>
    public static IResult ToProblemResult(
        this IError error,
        HttpContext context,
        bool includeDetails = false)
    {
        var (status, title, type, extensions) = PrepareProblemDetails(error, context, includeDetails);

        return TypedResults.Problem(
            detail: error.Message,
            instance: context.Request.Path,
            statusCode: status,
            title: title,
            type: type,
            extensions: extensions);
    }

    private static (int Status, string Title, string Type, IDictionary<string, object?> Extensions) PrepareProblemDetails(
        IError error,
        HttpContext context,
        bool includeDetails)
    {
        var problemDetailsSource = error as IProblemDetailsSource;
        var status = problemDetailsSource?.Status ?? StatusCodes.Status500InternalServerError;
        var title = problemDetailsSource?.Title ?? "Internal Server Error";
        var type = problemDetailsSource?.Type ?? "https://tools.ietf.org/html/rfc9110#section-15.6.1";

        var extensions = new Dictionary<string, object?>
        {
            ["code"] = error.Code,
            ["severity"] = error.Severity.ToString(),
            ["traceId"] = context.TraceIdentifier
        };

        if (error.Metadata is not null)
        {
            foreach (var kvp in error.Metadata)
            {
                extensions[kvp.Key] = kvp.Value;
            }
        }

        // Map specialized properties for known error types
        MapSpecializedProperties(error, extensions, includeDetails);

        return (status, title, type, extensions);
    }

    private static void MapSpecializedProperties(
        IError error,
        IDictionary<string, object?> extensions,
        bool includeDetails)
    {
        switch (error)
        {
            case IValidationError validationError:
                extensions["targetPath"] = validationError.TargetPath;
                extensions["targetName"] = validationError.TargetName;
                extensions["attemptedValue"] = validationError.AttemptedValue;
                break;
            
            case INotFoundError notFoundError:
                extensions["resourceType"] = notFoundError.ResourceType;
                extensions["resourceId"] = notFoundError.ResourceId;
                break;
            
            case IServiceUnavailableError serviceUnavailableError:
                if (serviceUnavailableError.ServiceName != null)
                {
                    extensions["serviceName"] = serviceUnavailableError.ServiceName;
                }

                if (serviceUnavailableError.RetryAfter != null)
                {
                    extensions["retryAfter"] = serviceUnavailableError.RetryAfter.Value.TotalSeconds;
                }

                break;
            
            case ITimeoutError timeoutError:
                if (timeoutError.Timeout != null)
                {
                    extensions["timeout"] = timeoutError.Timeout.Value.TotalSeconds;
                }

                break;
            
            case ITooManyRequestsError tooManyRequestsError:
                if (tooManyRequestsError.RetryAfter != null)
                {
                    extensions["retryAfter"] = tooManyRequestsError.RetryAfter.Value.TotalSeconds;
                }
                break;
            
            case IUnexpectedError unexpectedError:
                if (includeDetails && unexpectedError.Exception is not null)
                {
                    extensions["exception"] = unexpectedError.Exception.GetType().Name;
                    extensions["exceptionMessage"] = unexpectedError.Exception.Message;
                    extensions["stackTrace"] = unexpectedError.Exception.StackTrace;
                
                    if (unexpectedError.Exception.InnerException is not null)
                    {
                        extensions["innerException"] = unexpectedError.Exception.InnerException.GetType().Name;
                        extensions["innerExceptionMessage"] = unexpectedError.Exception.InnerException.Message;
                    }
                }
                break;
        }
    }
}
