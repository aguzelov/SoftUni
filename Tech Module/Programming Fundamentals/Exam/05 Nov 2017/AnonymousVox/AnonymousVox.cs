using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace AnonymousVox
{
    class AnonymousVox
    {

        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string[] placeholders = Console.ReadLine().Split(new char[] { '{', '}' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            string pattern = @"(?<start>[a-zA-Z]+)(?<placeholder>.+)(\k<start>)";

            MatchCollection matches = Regex.Matches(text, pattern);
            int index = 0;

            StringBuilder sb = new StringBuilder();

            foreach (Match match in matches)
            {
                string placeholder = match.Groups["placeholder"].Value;

                int indexOfPlaceholder = text.IndexOf(placeholder);

                sb.Append(text.Substring(0, indexOfPlaceholder));
                sb.Append(placeholders[index]);

                text = text.Remove(0, indexOfPlaceholder + placeholder.Length);

                index++;
                if (index >= placeholders.Length)
                {
                    index = 0;
                }
            }
            sb.Append(text);

            Console.WriteLine(sb);
        }

    }
}
