using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Files
{
    class Files
    {
        private static Dictionary<string, Dictionary<string, long>> files = new Dictionary<string, Dictionary<string, long>>();

        private static void Add(string root, string name, long size)
        {
            if (files.ContainsKey(root))
            {
                if (files[root].ContainsKey(name))
                {

                    files[root][name] = size;
                }
                else
                {
                    files[root].Add(name, size);
                }
            }
            else
            {
                files.Add(root, new Dictionary<string, long>());
                files[root].Add(name, size);
            }
        }

        private static void TakeInput()
        {
            string input = Console.ReadLine();

            string[] array = input.Split('\\').ToArray();

            string root = array[0];

            string[] fileNameAndSize = array[array.Length - 1].Split(';').ToArray();
            string filename = fileNameAndSize[0];
            long size = long.Parse(fileNameAndSize[1]);

            Add(root, filename, size);
        }

        private static void Print(string extension, string root)
        {
            bool isFind = false;
            if (!files.ContainsKey(root))
            {
                Console.WriteLine("No");
                return;
            }

            var fileData = files[root].OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToDictionary(k => k.Key, v => v.Value);

            foreach (var pair in fileData)
            {
                string[] nameAndExtension = pair.Key.Split('.').ToArray();
                if (nameAndExtension[nameAndExtension.Length - 1] == extension)
                {
                    isFind = true;
                    Console.WriteLine($"{pair.Key} - {pair.Value} KB");
                }
            }

            if (!isFind)
            {
                Console.WriteLine("No");
            }
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                TakeInput();
            }

            string[] array = Console.ReadLine().Split().ToArray();
            Print(array[0], array[2]);
        }
    }
}
