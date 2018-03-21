namespace P02.Graphic_Editor
{
    public class Square : IShape
    {
        private string type;

        public Square(string type)
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