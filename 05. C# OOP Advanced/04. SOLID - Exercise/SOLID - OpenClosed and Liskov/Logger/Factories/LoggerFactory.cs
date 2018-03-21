using Logging.Interfaces;
using Logging.Loggers;
using System;
using System.Collections.Generic;

namespace Logging.Factories
{
    public class LoggerFactory
    {
        public ILogger CreateLogger(LoggerTypes type, ICollection<IAppender> appenders)
        {
            switch (type)
            {
                case LoggerTypes.Logger:
                    return new Logger(appenders);

                default:
                    throw new ArgumentException("Invalid logger type!");
            }
        }
    }
}