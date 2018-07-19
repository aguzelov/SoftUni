using System;
using TeamBuilder.App.Core.Contracts;

namespace TeamBuilder.App.Core
{
    public class Engine
    {
        private IDispatcher dispatcher;

        public Engine(IDispatcher dispatcher)
        {
            this.dispatcher = dispatcher;
        }

        public void Run()
        {
            string output = this.dispatcher.Dispatch("InitializeDatabase");

            Console.WriteLine(output);
            while (true)
            {
                try
                {
                    string input = Console.ReadLine().Trim();
                    output = this.dispatcher.Dispatch(input);

                    Console.WriteLine(output);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.GetBaseException().Message);
                }
            }
        }
    }
}