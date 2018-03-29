namespace P08_CreateCustomClassAttribute.Core.Commands
{
    public class RevisionCommand : Command
    {
        public RevisionCommand(string typeName)
            : base(typeName)
        {
        }

        public override string Execute()
        {
            string result = this.Attribute.Revision.ToString();

            return $"Revision: {result}";
        }
    }
}