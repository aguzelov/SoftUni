using ProductShop.App.Commands.Contracts;
using ProductShop.Services.Contracts;

namespace ProductShop.App.Commands
{
    public class InitDatabaseCommand : ICommand
    {
        private readonly IDbService service;

        public InitDatabaseCommand(IDbService service)
        {
            this.service = service;
        }

        public void Execute()
        {
            service.InitDatabase();
        }
    }
}