using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudSecurity.Infrastructure.Logging
{
    /// <summary>
    /// Вспомогательный класс. Добавляет к объекту  ILoggerFactory метод расширения AddFile, который будет добавлять наш провайдер логгирования
    /// </summary>
    public static class FileLoggerExtensions
    {
        public static ILoggerFactory AddFile(this ILoggerFactory factory, string filePath)
        {
            factory.AddProvider(new FileLoggerProvider(filePath));
            return factory;
        }
    }
}
