namespace P08_CreateCustomClassAttribute.Core.Commands
{
    public class AuthorCommand : Command
    {
        public AuthorCommand(string typeName)
            : base(typeName)
        {
        }

        public override string Execute()
        {
            string result = this.Attribute.Author;

            return $"Author: {result}";
        }
    }
}