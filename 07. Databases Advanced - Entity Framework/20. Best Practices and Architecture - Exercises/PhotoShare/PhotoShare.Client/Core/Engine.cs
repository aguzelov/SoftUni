namespace PhotoShare.Client.Core
{
    using PhotoShare.Services.Contracts;
    using System;

    public class Engine
    {
        private readonly IDatabaseService databaseService;
        private readonly ICommandDispatcher commandDispatcher;

        public Engine(IDatabaseService databaseService, ICommandDispatcher commandDispatcher)
        {
            this.databaseService = databaseService;
            this.commandDispatcher = commandDispatcher;
        }

        public void Run()
        {
            // this.databaseService.InitializeDatabase();

            while (true)
            {
                try
                {
                    string input = Console.ReadLine().Trim();
                    string[] data = input.Split(' ');
                    string result = this.commandDispatcher.DispatchCommand(data);
                    Console.WriteLine(result.Trim());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}