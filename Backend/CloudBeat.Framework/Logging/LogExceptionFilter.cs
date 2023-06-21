using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace CloudBeat.Framework
{
    public class LogExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<LogExceptionFilter> _logger;

        public LogExceptionFilter(ILogger<LogExceptionFilter> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            _logger.LogError(context.Exception, "Unhandled exception occurred.");
        }
    }
}
