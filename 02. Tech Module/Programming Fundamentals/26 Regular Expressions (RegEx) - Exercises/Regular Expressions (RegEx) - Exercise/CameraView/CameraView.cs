using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CameraView
{
    class CameraView
    {
        static void Main(string[] args)
        {
            string[] mAndN = Console.ReadLine().Split(' ').ToArray();

            string line = Console.ReadLine();

            string pattern = @"(?<=\|<.{" + mAndN[0] + "})([^|]{0," + mAndN[1] + "})";

            Regex regex = new Regex(pattern);

            MatchCollection matches = regex.Matches(line);

            string[] names = matches.Cast<Match>()
                                    .Select(a => a.Value)
                                    .ToArray();

            Console.WriteLine(string.Join(", ", names));
        }
    }
}
