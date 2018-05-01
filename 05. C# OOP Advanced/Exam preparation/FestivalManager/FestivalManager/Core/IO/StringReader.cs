namespace FestivalManager.Core.IO
{
    public class StringReader
    {
        private readonly System.IO.StringReader reader;

        public StringReader(string contents)
        {
            this.reader = new System.IO.StringReader(contents);
        }

        public string ReadLine() => this.reader.ReadLine();
    }
}