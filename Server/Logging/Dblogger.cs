using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;
using System.Data.SqlClient;
using Microsoft.Extensions.Options;
using SCMDWH.Shared.Models;

namespace SCMDWH.Server.Logging
{

    public static class DbLoggerExtensions
    {
        public static ILoggingBuilder AddDbLogger(this ILoggingBuilder builder, Action<DbLoggerOptions> configure)
        {
            builder.Services.AddSingleton<ILoggerProvider, DbLoggerProvider>();
            builder.Services.Configure(configure);
            return builder;
        }
    }
    public class DbLogger : ILogger
    {
        
        private readonly DbLoggerProvider _dbLoggerProvider;

      
        public DbLogger([NotNull] DbLoggerProvider dbLoggerProvider)
        {
            _dbLoggerProvider = dbLoggerProvider;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

       
        public bool IsEnabled(LogLevel logLevel)
        {
            return logLevel != LogLevel.None;
        }

        public void Log<TState>(LogLevel logLevel,  EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {


                if (!IsEnabled(logLevel))
            {
                // Don't log the entry if it's not enabled.
                return;
            }

            var threadId = Thread.CurrentThread.ManagedThreadId; // Get the current thread ID to use in the log file. 

            // Store record.
            using (var connection = new SqlConnection(_dbLoggerProvider.Options.ConnectionString))
            {
                connection.Open();
                ErrorDataLog log = new();
                log.LogLevel = logLevel.ToString();
                log.EventName = "ServerIventNameJG";
                log.ExceptionMessage = exception?.Message;
                log.StackTrace = exception?.StackTrace;
                log.Source = "Server";
                log.CreatedDate = DateTime.Now.ToString();

                var values = new JObject();

                if (_dbLoggerProvider?.Options?.LogFields?.Any() ?? false)
                {
                    foreach (var logField in _dbLoggerProvider.Options.LogFields)
                    {
                        switch (logField)
                        {
                            case "LogLevel":
                                if (!string.IsNullOrWhiteSpace(logLevel.ToString()))
                                {
                                    if (state != null)
                                    {
                                        values["LogLevel"] = logLevel.ToString() + state.ToString();
                                    }
                                    else
                                    {
                                        values["LogLevel"] = logLevel.ToString();
                                    }

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


                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;

                    command.CommandText = string.Format("INSERT INTO {0} ([LogLevel],[EventName],[ExceptionMessage], [Source] , [StackTrace], [CreatedDate]) VALUES (@LogLevel,@EventName, @ExceptionMessage,@Source, @StackTrace , @CreatedDate)", "ErrorDataLog");

                    command.Parameters.Add(new SqlParameter("@LogLevel", log.LogLevel));
                    command.Parameters.Add(new SqlParameter("@EventName", log.EventName));
                    command.Parameters.Add(new SqlParameter("@ExceptionMessage", JsonConvert.SerializeObject(values, new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                        DefaultValueHandling = DefaultValueHandling.Ignore,
                        Formatting = Formatting.None
                    }).ToString()));

                     command.Parameters.Add(new SqlParameter("@Source", log.Source));

                    command.Parameters.Add(new SqlParameter("@StackTrace", JsonConvert.SerializeObject(values, new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                        DefaultValueHandling = DefaultValueHandling.Ignore,
                        Formatting = Formatting.None
                    }).ToString()));

                    command.Parameters.Add(new SqlParameter("@CreatedDate", DateTime.Now.ToString()));
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }
    }

    [ProviderAlias("Database")]
    public class DbLoggerProvider : ILoggerProvider
    {
        public readonly DbLoggerOptions Options;

        public DbLoggerProvider(IOptions<DbLoggerOptions> _options)
        {
            Options = _options.Value; // Stores all the options.
        }

       
        public ILogger CreateLogger(string categoryName)
        {
            return new DbLogger(this);
        }

        public void Dispose()
        {
        }
    }

    public class DbLoggerOptions
    {
        public string ConnectionString { get; init; }

        public string[] LogFields { get; init; }

        public string LogTable { get; init; }

        public DbLoggerOptions()
        {
        }
    }
}
