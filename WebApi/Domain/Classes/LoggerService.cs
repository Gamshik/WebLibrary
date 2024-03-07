using Domain.Interfaces;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Classes
{
    public class LoggerService : ILoggerService
    {
        private static ILogger _logger = LogManager.GetCurrentClassLogger();
        public LoggerService()
        {
        }
        public void LogDebug(string message)
        {
            _logger.Debug(message);
        }

        public void LogError(string message)
        {
            _logger.Error(message);
        }

        public void LogInfo(string message)
        {
            _logger.Info(message);
        }

        public void LogWarning(string message)
        {
            _logger.Warn(message);
        }
    }
}
