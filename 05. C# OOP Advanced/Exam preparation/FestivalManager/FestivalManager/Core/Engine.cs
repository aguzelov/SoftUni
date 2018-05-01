using System;
using System.Linq;

namespace FestivalManager.Core
{
    using Contracts;
    using Controllers.Contracts;
    using FestivalManager.Core.IO;
    using IO.Contracts;
    using System.Reflection;

    public class Engine : IEngine
    {
        public IReader reader;
        public IWriter writer;

        public IFestivalController festivalCоntroller;
        public ISetController setCоntroller;

        public Engine(IFestivalController festivalController, ISetController setController)
        {
            this.festivalCоntroller = festivalController;
            this.setCоntroller = setController;

            this.reader = new ConsoleReader();
            this.writer = new ConsoleWriter();
        }

        public void Run()
        {
            while (true)
            {
                var input = reader.ReadLine();

                if (input == "END")
                    break;

                try
                {
                    var result = this.ProcessCommand(input);
                    this.writer.WriteLine(result);
                }
                catch (Exception ex)
                {
                    this.writer.WriteLine("ERROR: " + ex.Message);
                }
            }

            var end = this.festivalCоntroller.ProduceReport();

            this.writer.WriteLine("Results:");
            this.writer.WriteLine(end);
        }

        public string ProcessCommand(string input)
        {
            var tokens = input.Split(" ".ToCharArray().First());

            var commandName = tokens.First();
            var args = tokens.Skip(1).ToArray();

            string result = null;

            if (commandName == "LetsRock")
            {
                result = this.setCоntroller.PerformSets();
                return result;
            }

            var festivalcontrolType = this.festivalCоntroller.GetType()
                .GetMethods()
                .FirstOrDefault(x => x.Name == commandName);

            try
            {
                result = (string)festivalcontrolType.Invoke(this.festivalCоntroller, new object[] { args });
            }
            catch (TargetInvocationException tie)
            {
                throw tie.InnerException;
            }

            return result;
        }
    }
}