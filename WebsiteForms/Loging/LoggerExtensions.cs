using WebsiteForms.Loging.Models;

namespace WebsiteForms.Loging
{
    static class LoggerExtensions
    {
        public static ILoggingBuilder AddDbLogger(this ILoggingBuilder builder, Action<LoggerSettings> options)
        {
            builder.Services.AddSingleton<ILoggerProvider, LoggerProvider>();
            builder.Services.Configure(options);
            return builder;
        }
    }
}
