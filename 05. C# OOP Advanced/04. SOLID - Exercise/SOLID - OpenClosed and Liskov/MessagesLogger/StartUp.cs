using Logging.Factories;

namespace MessagesLogger
{
    public class StartUp
    {
        private static void Main(string[] args)
        {
            LoggerFactory loggerFactory = new LoggerFactory();
            AppenderFactory appenderFactory = new AppenderFactory();
            LayoutFactory layoutFactory = new LayoutFactory();

            Engine engine = new Engine(loggerFactory, appenderFactory, layoutFactory);

            engine.Run();
        }
    }
}