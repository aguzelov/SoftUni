namespace P08_CreateCustomClassAttribute.Core.Commands
{
    public class DescriptionCommand : Command
    {
        public DescriptionCommand(string typeName)
            : base(typeName)
        {
        }

        public override string Execute()
        {
            string result = this.Attribute.Description;

            return $"Class description: {result}";
        }
    }
}