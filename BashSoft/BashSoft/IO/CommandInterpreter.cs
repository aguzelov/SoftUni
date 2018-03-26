using BashSoft.Attributes;
using BashSoft.Contracts;
using BashSoft.IO.Commands;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace BashSoft
{
    public class CommandInterpreter : IInterpreter
    {
        private IContentComparer judge;
        private IDatabase repository;
        private IDirectoryManager inputOutputIoManager;

        public CommandInterpreter(IContentComparer judge, IDatabase repository, IDirectoryManager inputOutputIoManager)
        {
            this.judge = judge;
            this.repository = repository;
            this.inputOutputIoManager = inputOutputIoManager;
        }

        public void InterpredCommand(string input)
        {
            string[] data = input.Split(' ');
            string commandName = data[0];
            try
            {
                IExecutable command = this.ParseCommand(input, data, commandName);
                command.Execute();
            }
            catch (DirectoryNotFoundException dnfe)
            {
                OutputWriter.DisplayException(dnfe.Message);
            }
            catch (ArgumentOutOfRangeException aoore)
            {
                OutputWriter.DisplayException(aoore.Message);
            }
            catch (ArgumentException ae)
            {
                OutputWriter.DisplayException(ae.Message);
            }
            catch (Exception ex)
            {
                OutputWriter.DisplayException(ex.Message);
            }
        }

        private IExecutable ParseCommand(string input, string[] data, string command)
        {
            object[] paramenterForConstruction = new object[]
            {
                input, data
            };

            Type typeOfCommand = null;

            foreach (var type in Assembly.GetExecutingAssembly()
                .GetTypes())
            {
                object[] attrs = type.GetCustomAttributes(true);

                foreach (var attr in attrs)
                {
                    if (attr is AliasAttribute aliasAttribute && aliasAttribute.Name == command)
                    {
                        typeOfCommand = type;
                        break;
                    }
                }
            }

            Type typeOfInterpreter = typeof(CommandInterpreter);

            Command exe = (Command)Activator.CreateInstance(typeOfCommand, paramenterForConstruction);

            FieldInfo[] fieldsOfCommand = typeOfCommand
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            FieldInfo[] fieldsOfInterpreter = typeOfInterpreter
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (var fieldOFCommand in fieldsOfCommand)
            {
                Attribute atrAttribute = fieldOFCommand.GetCustomAttribute(typeof(InjectAttribute));
                if (atrAttribute != null)
                {
                    if (fieldsOfInterpreter.Any(x => x.FieldType == fieldOFCommand.FieldType))
                    {
                        fieldOFCommand.SetValue(exe,
                            fieldsOfInterpreter.First(x => x.FieldType == fieldOFCommand.FieldType)
                            .GetValue(this));
                    }
                }
            }

            return exe;
        }
    }
}