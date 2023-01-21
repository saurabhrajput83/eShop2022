using eShop.BLL.AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.BLL.Logging
{
    public static class LoggerConfiguration
    {
        private static ILoggerFactory GetLoggerFactory()
        {

            return LoggerFactory.Create(loggingBuilder => loggingBuilder
             .SetMinimumLevel(LogLevel.Trace)
             //.AddApplicationInsights(builder.Configuration["APPINSIGHTS_CONNECTIONSTRING"])
             );
        }

        public static ILogger<T> Configuration<T>()
        {
            ILoggerFactory factory = GetLoggerFactory();
            return factory.CreateLogger<T>();
        }
    }
}
