using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Data.SqlClient;
using WebsiteForms.Database;

namespace WebsiteForms.Loging
{
    public class Logger : ILogger
    {
        private readonly LoggerProvider _provider;

        public Logger(LoggerProvider provider)
        {
            _provider = provider;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            var minLogLevel = LogLevel.None;
            try
            {
                minLogLevel = (LogLevel)Enum.Parse(typeof(LogLevel), _provider.Options.MinLogLevel, true);
            }
            catch (Exception)
            {
                throw new Exception("Invalid LogLevel provided in configuration. Defaulting to 'None'");
            }
            return logLevel > minLogLevel;
        }

        void ILogger.Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            if (!IsEnabled(logLevel))
                return;

            var values = new JObject();

            var json = CreateJsonBody<TState>(values, logLevel, eventId, state, exception, formatter);

            InsertLog(json);
        }
        private string CreateJsonBody<TState>(JObject values, LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            var threadId = Thread.CurrentThread.ManagedThreadId;
            if (_provider?.Options?.LogFields?.Any() ?? false)
            {
                foreach (var logField in _provider.Options.LogFields)
                {
                    switch (logField)
                    {
                        case "LogLevel":
                            if (!string.IsNullOrWhiteSpace(logLevel.ToString()))
                            {
                                values["LogLevel"] = logLevel.ToString();
                            }
                            break;
                        case "ThreadId":
                            values["ThreadId"] = threadId;
                            break;
                        case "EventId":
                            values["EventId"] = eventId.Id;
                            break;
                        case "EventName":
                            if (!string.IsNullOrWhiteSpace(eventId.Name))
                            {
                                values["EventName"] = eventId.Name;
                            }
                            break;
                        case "Message":
                            if (!string.IsNullOrWhiteSpace(formatter(state, exception)))
                            {
                                values["Message"] = formatter(state, exception);
                            }
                            break;
                        case "ExceptionMessage":
                            if (exception != null && !string.IsNullOrWhiteSpace(exception.Message))
                            {
                                values["ExceptionMessage"] = exception?.Message;
                            }
                            break;
                        case "ExceptionStackTrace":
                            if (exception != null && !string.IsNullOrWhiteSpace(exception.StackTrace))
                            {
                                values["ExceptionStackTrace"] = exception?.StackTrace;
                            }
                            break;
                        case "ExceptionSource":
                            if (exception != null && !string.IsNullOrWhiteSpace(exception.Source))
                            {
                                values["ExceptionSource"] = exception?.Source;
                            }
                            break;
                    }
                }
            }

            return JsonConvert.SerializeObject(values);
        }
        private void InsertLog(string data)
        {
            using (SqlConnection openCon = new SqlConnection(DbSettings.GetConnectionString()))
            {
                string saveLog = "INSERT INTO Logs (JsonData, CreatedBy, CreatedAt) VALUES (@data, @createdBy, @createdAt)";

                using (SqlCommand querySaveLog = new SqlCommand(saveLog))
                {
                    querySaveLog.Connection = openCon;
                    querySaveLog.Parameters.Add("@data", SqlDbType.VarChar).Value = data;
                    querySaveLog.Parameters.Add("@createdBy", SqlDbType.VarChar).Value = "system";
                    querySaveLog.Parameters.Add("@createdAt", SqlDbType.DateTime).Value = DateTime.Now;
                    openCon.Open();

                    querySaveLog.ExecuteNonQuery();
                }
            }
        }
    }
}
