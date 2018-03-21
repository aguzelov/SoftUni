namespace P02.Graphic_Editor
{
    public class Rectangle : IShape
    {
        private string type;

        public Rectangle(string type)
        {
            Type = type;
        }

        public string Type
        {
            get
            {
                return this.type;
            }
            private set
            {
                this.type = value;
            }
        }

        public override string ToString()
        {
            return $"I'm {Type}";
        }
    }
}