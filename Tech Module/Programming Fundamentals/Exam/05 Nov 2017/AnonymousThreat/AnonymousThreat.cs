using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace AnonymousThreat
{
    class AnonymousThreat
    {
        private static List<string> data = new List<string>();

        static void Main(string[] args)
        {
            data = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            while (TakeCommand()) { }
        }

        private static void Print()
        {
            Console.WriteLine(string.Join(" ", data));
        }

        private static bool TakeCommand()
        {
            string input = Console.ReadLine();
            if(input== "3:1")
            {
                Print();
                return false;
            }

            string[] command = input.Split(' ').ToArray();

            switch (command[0])
            {
                case "merge":
                    int startIndex = int.Parse(command[1]);
                    int endIndex = int.Parse(command[2]);
                    Merge(startIndex, endIndex);
                    break;
                case "divide":
                    int index = int.Parse(command[1]);
                    int count = int.Parse(command[2]);
                    Divide(index, count);
                    break;
            }
            return true;
        }

        private static void Divide(int index, int count)
        {
            string element = data[index];
            
            int part = (int)Math.Round((double)(element.Length / count));
            
            List<string> parts = new List<string>();
            
            int counter = 1;

            string sub;
            while (element.Length != 0)
            {
                if(counter < count)
                {
                    sub = element.Substring(0, part);
                    parts.Add(sub);
                    element = element.Remove(0, part);
                }
                else
                {
                    sub = element.Substring(0, element.Length);
                    parts.Add(sub);
                    element = element.Remove(0, element.Length);
                }
                counter++;
            }
            
            data.RemoveAt(index);
            data.InsertRange(index, parts);
        }
        
        private static void Merge(int startIndex, int endIndex)
        {
            if(startIndex < 0)
            {
                startIndex = 0;
            }
            if(startIndex > data.Count - 1)
            {
                startIndex = data.Count - 1;
            }

            if (endIndex < 0)
            {
                endIndex = 0;
            }
            if (endIndex > data.Count - 1)
            {
                endIndex = data.Count - 1;
            }

            List<string> elements = new List<string>();

            for(int i = startIndex; i <= endIndex; i++)
            {
                elements.Add(data[i]);
            }

            if(startIndex == data.Count - 1)
            {
                data.RemoveAt(startIndex);
            }
            else
            {
                data.RemoveRange(startIndex, elements.Count);
            }
            
            data.Insert(startIndex, string.Join("", elements));
        }
    }
}
