

using Common.Enums;

namespace Services
{
    public interface ILoggerService
    {
        void LogWarning(string message);
        void Log(E_LogLevel logLevel, string message, Exception? ex = null);
    }

    public class LoggerService : ILoggerService
    {

        public void LogWarning(string message)
        {
            Log(E_LogLevel.Warning, message);
        }

        public void Log(E_LogLevel logLevel, string message, Exception? ex = null)
        {
            var errorMessage = ex == null ? message : $"{message} - Exception: {ex.Message}";
            Log(logLevel, errorMessage);
        }

        private void Log(E_LogLevel logLevel, string message)
        {
            Console.WriteLine($"[{DateTime.Now}] {logLevel}: {message}");
        }

    }
}
