namespace PhotoShare.Client.Core.Commands
{
    using Models;
    using PhotoShare.Client.Core.Commands.Contracts;
    using PhotoShare.Client.Validation;
    using PhotoShare.Services.Contracts;
    using Utilities;

    [Credential(true)]
    public class AddTagCommand : ICommand
    {
        private readonly ITagService service;

        public AddTagCommand(ITagService service)
        {
            this.service = service;
        }

        // AddTag <tag>
        public string Execute(string[] data)
        {
            string tagName = data[0].ValidateOrTransform();

            Tag tag = service.AddTag(tagName);

            return $"Tag {tag.Name} was added successfully!";
        }
    }
}