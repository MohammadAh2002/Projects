using Contracts.ILogging;
using NLog;

namespace LoggerService.LoggerManager
{
    public class LoggerManager : ILoggerManager
    {
        private static ILogger _Logger = LogManager.GetCurrentClassLogger();
        public LoggerManager()
        {
        }

        public void LogDebug(string message) => _Logger.Debug(message);
        public void LogError(string message) => _Logger.Error(message);
        public void LogInfo(string message) => _Logger.Info(message);
        public void LogWarn(string message) => _Logger.Warn(message);
    }

}
