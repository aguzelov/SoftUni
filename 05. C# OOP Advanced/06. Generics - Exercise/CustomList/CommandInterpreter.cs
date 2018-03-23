using System;

namespace CustomList
{
    public class CommandInterpreter
    {
        private ICustomList<string> list;
        private Sorter sorter;

        public CommandInterpreter(ICustomList<string> list)
        {
            this.list = list;
            this.sorter = new Sorter();
        }

        public void Run()
        {
            while (true)
            {
                string[] inputArgs = Console.ReadLine().Split();
                string command = inputArgs[0].ToString();

                string result = string.Empty;
                switch (command)
                {
                    case "Add":
                        string element = inputArgs[1];
                        this.list.Add(element);
                        break;

                    case "Remove":
                        int index = int.Parse(inputArgs[1]);
                        result = this.list.Remove(index);
                        result = string.Empty;
                        break;

                    case "Contains":
                        element = inputArgs[1];
                        result = this.list.Contains(element).ToString();
                        break;

                    case "Swap":
                        int first = int.Parse(inputArgs[1]);
                        int second = int.Parse(inputArgs[2]);
                        this.list.Swap(first, second);
                        break;

                    case "Greater":
                        element = inputArgs[1];
                        result = this.list.CountGreaterThan(element).ToString();
                        break;

                    case "Max":
                        result = this.list.Max();
                        break;

                    case "Min":
                        result = this.list.Min();
                        break;

                    case "Sort":
                        this.list.Sort();
                        break;

                    case "Print":
                        result = string.Join($"{Environment.NewLine}", this.list);
                        break;

                    case "END":
                        return;
                }
                if (result != string.Empty)
                    Console.WriteLine(result);
            }
        }
    }
}