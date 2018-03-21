using Logging;
using Logging.Factories;
using Logging.Interfaces;
using Logging.Layouts;
using Logging.Loggers;
using Logging.Reports;
using System;
using System.Collections.Generic;

namespace MessagesLogger
{
    public class Engine
    {
        private readonly LoggerFactory loggerFactory;
        private readonly AppenderFactory appenderFactory;
        private readonly LayoutFactory layoutFactory;

        private ILogger logger;
        private LoggerTypes loggerType = LoggerTypes.Logger;

        private ICollection<IAppender> appenders;

        private Engine()
        {
            this.appenders = new List<IAppender>();
        }

        public Engine(LoggerFactory loggerFactory, AppenderFactory appenderFactory, LayoutFactory layoutFactory) : this()
        {
            this.loggerFactory = loggerFactory;
            this.appenderFactory = appenderFactory;
            this.layoutFactory = layoutFactory;

            GetAppenders();
            SetLogger(this.loggerType);
        }

        private void GetAppenders()
        {
            var numberOFAppeders = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOFAppeders; i++)
            {
                string[] inputArgs = Console.ReadLine().Split(" ");

                AppendersType appenderType = Enum.Parse<AppendersType>(inputArgs[0]);
                LayoutsType layoutType = Enum.Parse<LayoutsType>(inputArgs[1]);

                ILayout layout = layoutFactory.CreateLayout(layoutType);
                IAppender appender = appenderFactory.CreateAppender(appenderType, layout);

                if (inputArgs.Length == 3)
                {
                    string reportLevelType = inputArgs[2];
                    ReportLevel level = Enum.Parse<ReportLevel>(reportLevelType);

                    appender.ReportLevel = level;
                }

                if (appenderType == AppendersType.FileAppender)
                    ((FileAppender)appender).File = new LogFile();

                appenders.Add(appender);
            }
        }

        public void SetLogger(LoggerTypes type)
        {
            this.logger = loggerFactory.CreateLogger(type, this.appenders);
        }

        public void Run()
        {
            while (true)
            {
                string[] messageArgs = Console.ReadLine().Split("|");

                if (messageArgs.Length == 1)
                {
                    Console.WriteLine(this.logger.ToString());

                    break;
                }

                ReportLevel reportLevel = Enum.Parse<ReportLevel>(messageArgs[0]);
                string dateTime = messageArgs[1];
                string message = messageArgs[2];

                IReport report = new Report(reportLevel, dateTime, message);

                this.logger.Append(report);
            }
        }
    }
}