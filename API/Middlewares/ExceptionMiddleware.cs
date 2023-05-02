using API.Errors;
using System.Net;
using System.Text.Json;

namespace API.Middlewares
{
    /// <summary>
    /// Represents a middleware component for handling exceptions that occur during request processing.
    /// </summary>
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        private readonly IHostEnvironment _env;

        /// <summary>
        /// Initializes a new instance of the ExceptionMiddleware class with the given dependencies.
        /// </summary>
        /// <param name="next">The next request delegate in the pipeline.</param>
        /// <param name="logger">The logger to use for logging exceptions.</param>
        /// <param name="env">The hosting environment in which the application is running.</param>
        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger,
            IHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }

        /// <summary>
        /// Invokes the middleware to handle exceptions that occur during request processing.
        /// </summary>
        /// <param name="context">The HTTP context for the current request.</param>
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                // Pass the request down the pipeline.
                await _next(context);
            }
            catch (Exception ex)
            {
                // Log the exception and set the response status code and content type.
                _logger.LogError(ex, ex.Message);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                // Create a JSON response containing the exception details.
                var response = _env.IsDevelopment()
                    ? new ApiException((int)HttpStatusCode.InternalServerError, ex.Message,
                    ex.StackTrace.ToString()) : new ApiException((int)HttpStatusCode.InternalServerError);
                var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
                var json = JsonSerializer.Serialize(response, options);

                // Write the response to the HTTP response body.
                await context.Response.WriteAsync(json);
            }
        }
    }

}
