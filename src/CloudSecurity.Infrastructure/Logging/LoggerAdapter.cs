using CloudSecurity.Core.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace CloudSecurity.Infrastructure.Logging
{
    public class LoggerAdapter<T> : IAppLogger<T>
    {
        private readonly ILogger _logger;
        private readonly ILogger<T> _loggerFile;
        public LoggerAdapter(ILoggerFactory loggerFactory, string path=null)
        {           
            _logger = loggerFactory.CreateLogger<T>();
         
        }

        public void LogInformation(string message, params object[] args)
        {
            _logger.LogInformation(message, args);
        }

        public void LogWarning(string message, params object[] args)
        {
            _logger.LogWarning(message, args);
        }

        
    }
}
