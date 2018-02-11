using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.IO;


namespace AMinerTask
{
    class AMinerTask
    {
        private static readonly string inputFileName = "input.txt";

        private static readonly string outputFileName = "output.txt";
        
        static Dictionary<string, string> resources = new Dictionary<string, string> { };

        static void AddResources(string resource, string quantity)
        {
            if (resources.ContainsKey(resource))
            {
                BigInteger currQuantity = BigInteger.Parse(resources[resource]);

                BigInteger newQuantity = currQuantity + (BigInteger.Parse(quantity));

                resources[resource] = newQuantity.ToString();
            }
            else
            {
                resources.Add(resource, quantity);
            }
        }

        static void PrintResources()
        {
            foreach (KeyValuePair<string, string> pair in resources)
            {
                WriteToFile($"{pair.Key} -> {pair.Value}");
            }
            WriteToFile(String.Empty);
        }

        static void WriteToFile(string text)
        {
            using (StreamWriter writer = new StreamWriter(outputFileName, true))
            {
                writer.WriteLine(text);
            }
        }

        static void CleanOutputFile()
        {
            using (StreamWriter writer = new StreamWriter(outputFileName, false))
            {
                writer.Write(String.Empty);
            }
        }

        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines(inputFileName);

            int resourceIndex = 0;
            int quantityIndex = 1;

            while (lines[resourceIndex] != "stop")
            {
                AddResources(lines[resourceIndex], lines[quantityIndex]);
                resourceIndex += 2;
                quantityIndex += 2;
            }

            CleanOutputFile();

            PrintResources();
        }
    }
}
