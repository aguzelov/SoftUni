using _03BarracksFactory.Core.Attributes;
using _03BarracksFactory.Core.Commands;
using System.Linq;
using System.Reflection;

namespace _03BarracksFactory.Core
{
    using Contracts;
    using System;

    internal class Engine : IRunnable
    {
        private IRepository repository;
        private IUnitFactory unitFactory;

        public Engine(IRepository repository, IUnitFactory unitFactory)
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    string input = Console.ReadLine();
                    string[] data = input.Split();
                    string commandName = data[0];

                    IExecutable command = ParseCommand(data, commandName);
                    string result = command.Execute();
                    if (result == "exit") break;
                    Console.WriteLine(result);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        // TODO: refactor for Problem 4
        private IExecutable ParseCommand(string[] data, string commandName)
        {
            object[] paramenterForConstruction = new object[]
            {
                data
            };

            Type commandType = Assembly.GetExecutingAssembly().GetTypes().First(t => t.Name.ToLower().Contains(commandName));

            Command command = (Command)Activator.CreateInstance(commandType, paramenterForConstruction);

            FieldInfo[] fieldInfos = commandType.GetFields(
                BindingFlags.Instance |
                BindingFlags.NonPublic);

            FieldInfo[] engineFieldInfos = typeof(Engine).GetFields(
                BindingFlags.Instance |
                BindingFlags.NonPublic);

            foreach (var fieldInfo in fieldInfos)
            {
                Attribute attribute = fieldInfo.GetCustomAttribute(typeof(InjectAttribute));
                if (attribute != null)
                {
                    if (engineFieldInfos.Any(f => f.FieldType == fieldInfo.FieldType))
                    {
                        fieldInfo.SetValue(command,
                            engineFieldInfos.First(x => x.FieldType == fieldInfo.FieldType).GetValue(this));
                    }
                }
            }

            return command;
        }
    }
}