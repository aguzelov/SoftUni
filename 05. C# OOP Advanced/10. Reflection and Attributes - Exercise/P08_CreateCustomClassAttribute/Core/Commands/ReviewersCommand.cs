namespace P08_CreateCustomClassAttribute.Core.Commands
{
    public class ReviewersCommand : Command
    {
        public ReviewersCommand(string typeName)
            : base(typeName)
        {
        }

        public override string Execute()
        {
            string result = string.Join(", ", this.Attribute.Reviewers);

            return $"Reviewers: {result}";
        }
    }
}