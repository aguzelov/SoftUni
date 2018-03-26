using BashSoft.Contracts;
using System;

namespace BashSoft
{
    public class InputReader : IReader
    {
        private const string endCommand = "quit";
        private IInterpreter interpreter;

        public InputReader(IInterpreter interpreter)
        {
            this.interpreter = interpreter;
        }

        public void StartReadingCommands()
        {
            string input = "";
            while (input != endCommand)
            {
                OutputWriter.WriteMessage($"{SessionData.currentPath}>");
                input = Console.ReadLine();
                input = input.Trim();
                this.interpreter.InterpredCommand(input);
            }
        }
    }
}