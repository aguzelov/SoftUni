using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Files
{
    class Files
    {
         static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<string> files = new List<string>();
            for(int i = 0;i < n; i++)
            {
                files.Add(Console.ReadLine());
            }

            string[] input = Console.ReadLine().Split(new string[] { " in " }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            files.RemoveAll(x => !x.StartsWith(input[1] + "\\"));

            Dictionary<string, long> filenameAndSize = new Dictionary<string, long>();

            foreach(string file in files)
            {
                string[] pathAndSize = file.Split(';').ToArray();
                long size = long.Parse(pathAndSize[1]);
                string filename = pathAndSize[0].Split('\\').Last();
                if(filename.EndsWith("." + input[0]))
                {
                    filenameAndSize[filename] = size;
                }
            }

            foreach(var pair in filenameAndSize.OrderByDescending(x=> x.Value).ThenBy(x=> x.Key))
            {
                Console.WriteLine($"{pair.Key} - {pair.Value} KB");
            }
            if(filenameAndSize.Count == 0)
            {
                Console.WriteLine("No");
            }
        }
    }
}
