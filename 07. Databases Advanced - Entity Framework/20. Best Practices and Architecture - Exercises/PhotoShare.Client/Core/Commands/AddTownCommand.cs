namespace PhotoShare.Client.Core.Commands
{
    using Models;
    using PhotoShare.Client.Core.Commands.Contracts;
    using PhotoShare.Client.Validation;
    using PhotoShare.Services.Contracts;

    [CredentialAttribute(true)]
    public class AddTownCommand : ICommand
    {
        private readonly ITownService service;

        public AddTownCommand(ITownService service)
        {
            this.service = service;
        }

        // AddTown <townName> <countryName>
        public string Execute(string[] data)
        {
            string townName = data[0];
            string country = data[1];

            Town town = service.AddTown(townName, country);

            return $"Town {town.Name} was added successfully!";
        }
    }
}