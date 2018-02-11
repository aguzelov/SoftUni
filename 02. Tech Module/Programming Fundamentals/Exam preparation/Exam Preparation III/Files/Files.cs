using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Files
{
    class Files
    {
        private static Dictionary<string, Dictionary<string, long>> files = new Dictionary<string, Dictionary<string, long>>();

        private static void TakeInput()
        {
            string input = Console.ReadLine();

            string[] array = input.Split('\\').ToArray();

            string root = array[0];

            string[] fileNameAndSize = array[array.Length - 1].Split(';');

            string fullName = fileNameAndSize[0];
            long size = long.Parse(fileNameAndSize[1]);

            if (files.ContainsKey(root))
            {
                if (files[root].ContainsKey(fullName))
                {
                    files[root][fullName] = size;
                }
                else
                {
                    files[root].Add(fullName, size);
                }
            }
            else
            {
                files.Add(root, new Dictionary<string, long>());
                files[root].Add(fullName, size);
            }
        }

        private static void PrintResult(string extension, string root)
        {
            bool isFound = false;

            if (!files.ContainsKey(root))
            {
                Console.WriteLine("No");
                return;
            }
            var fileData = files[root].OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .ToDictionary(k => k.Key, v => v.Value);

            foreach (var pair in fileData)
            {
                string[] fileNameAndExtension = pair.Key.Split('.').ToArray();
                if (fileNameAndExtension[fileNameAndExtension.Length - 1] == extension)
                {
                    isFound = true;
                    Console.WriteLine($"{pair.Key} - {pair.Value} KB");
                }
            }

            if (!isFound)
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

            string[] extensionAndRoot = Console.ReadLine().Split().ToArray();
            string extensionToFind = extensionAndRoot[0];
            string rootToFind = extensionAndRoot[2];
            PrintResult(extensionToFind, rootToFind);
        }
    }

}
