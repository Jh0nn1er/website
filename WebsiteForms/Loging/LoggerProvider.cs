using Microsoft.Extensions.Options;
using WebsiteForms.Loging.Models;

namespace WebsiteForms.Loging
{
    public class LoggerProvider : ILoggerProvider
    {
        public LoggerSettings Options;

        public LoggerProvider(LoggerSettings options)
        {
            Options = options;
        }
        public LoggerProvider(IOptions<LoggerSettings> options)
        {
            Options = options.Value;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new Logger(this);
        }

        public void Dispose()
        {
        }
    }
}
