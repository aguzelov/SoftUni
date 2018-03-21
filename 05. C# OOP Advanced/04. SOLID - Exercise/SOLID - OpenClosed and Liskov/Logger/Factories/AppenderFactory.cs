using Logging.Appenders;
using Logging.Interfaces;
using System;

namespace Logging.Factories
{
    public class AppenderFactory
    {
        public IAppender CreateAppender(AppendersType type, ILayout layout)
        {
            switch (type)
            {
                case AppendersType.ConsoleAppender:
                    return new ConsoleAppender(layout);

                case AppendersType.FileAppender:
                    return new FileAppender(layout);

                default:
                    throw new ArgumentException("Incorect appender type");
            }
        }
    }
}