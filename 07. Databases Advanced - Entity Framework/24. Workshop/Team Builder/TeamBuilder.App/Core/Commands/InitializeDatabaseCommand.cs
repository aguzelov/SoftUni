using TeamBuilder.App.Core.Commands.Contracts;
using TeamBuilder.Services.Contracts;

namespace TeamBuilder.App.Core.Commands
{
    public class InitializeDatabaseCommand : ICommand
    {
        private readonly IDbService dbService;

        public InitializeDatabaseCommand(IDbService dbService)
        {
            this.dbService = dbService;
        }

        public string Execute(string[] commandArg)
        {
            this.dbService.Initialize();

            return "Database is Initialized!";
        }
    }
}