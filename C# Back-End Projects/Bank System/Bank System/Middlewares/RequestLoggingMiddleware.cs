using Serilog;

public class RequestLoggingMiddleware
{
    private readonly RequestDelegate _next;

    public RequestLoggingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        string method = context.Request.Method;
        string path = context.Request.Path;

        await _next(context);

        long statusCode = context.Response.StatusCode;

        Log.Information("Request {Method} to {Path} responded with {StatusCode}", method, path, statusCode);
    }
}

public static class RequestLoggingMiddlewareExtensions
{
    public static IApplicationBuilder UseRequestLogging(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<RequestLoggingMiddleware>();
    }
}