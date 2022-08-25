using System.Net;
using System.Text.Json;
using VotingSystem.API.Model;

namespace VotingSystem.API.Middleware
{
    /// <summary>
    ///     ExceptionHandler
    /// </summary>
    public class ExceptionHandler
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandler> _logger;
        private readonly IHostEnvironment _hostEnvironment;

        public ExceptionHandler(
            RequestDelegate next, 
            ILogger<ExceptionHandler> logger,
            IHostEnvironment hostEnvironment)
        {
            _next = next;
            _logger = logger;
            _hostEnvironment = hostEnvironment;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
              await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,ex.Message);
                httpContext.Response.ContentType = "application/json";
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var response = _hostEnvironment.IsDevelopment() ?
                    new ExceptionResponse((int)HttpStatusCode.InternalServerError, ex.Message, ex.StackTrace.ToString())
                    : new ExceptionResponse((int)HttpStatusCode.InternalServerError);

                var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase};
                var json =  JsonSerializer.Serialize(response, options);

                await httpContext.Response.WriteAsync(json);
            }
        }
    }
}