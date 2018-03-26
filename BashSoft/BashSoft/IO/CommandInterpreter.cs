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
            //switch (command)
            //{
            //    case "open":
            //        return new OpenFileCommand(input, data, this.judge, this.repository, this.inputOutputIoManager);

            //    case "mkdir":
            //        return new MakeDirectoryCommand(input, data, this.judge, this.repository, this.inputOutputIoManager);

            //    case "ls":
            //        return new TraverseFoldersCommand(input, data, this.judge, this.repository, this.inputOutputIoManager);

            //    case "cmp":
            //        return new CompareFilesCommand(input, data, this.judge, this.repository, this.inputOutputIoManager);

            //    case "cdRel":
            //        return new ChangeRelativePathCommand(input, data, this.judge, this.repository, this.inputOutputIoManager);

            //    case "cdAbs":
            //        return new ChangeAbsolutePathCommand(input, data, this.judge, this.repository, this.inputOutputIoManager);

            //    case "readDb":
            //        return new ReadDatabaseCommand(input, data, this.judge, this.repository, this.inputOutputIoManager);

            //    case "help":
            //        return new GetHelpCommand(input, data, this.judge, this.repository, this.inputOutputIoManager);

            //    //case ":q!":
            //    //case "logout":
            //    case "exit":
            //        return new CloseConsoleCommand(input, data, this.judge, this.repository, this.inputOutputIoManager);

            //    case "show":
            //        return new ShowCourseCommand(input, data, this.judge, this.repository, this.inputOutputIoManager);

            //    case "filter":
            //        return new PrintFilteredStudentsCommand(input, data, this.judge, this.repository, this.inputOutputIoManager);

            //    case "order":
            //        return new PrintOrderedStudentsCommand(input, data, this.judge, this.repository, this.inputOutputIoManager);

            //    case "dropdb":
            //        return new DropDatabaseCommand(input, data, this.judge, this.repository, this.inputOutputIoManager);

            //    case "display":
            //        return new DisplayCommand(input, data, this.judge, this.repository, this.inputOutputIoManager);

            //    case "download":
            //    //TODO: implement after functionality is implemented
            //    case "downloadAsynch":
            //    //TODO: implement after functionality is implemented
            //    default:
            //        throw new InvalidCommandException(input);
            //}

            object[] paramenterForConstruction = new object[]
            {
                input, data
            };


            //TODO: Find why this always is CommandInterpreter type
            Type typeOfCommand = null;
            //Assembly.GetExecutingAssembly()
            //.GetTypes()
            //.First(type =>
            //    type.GetCustomAttributes(typeof(AliasAttribute))
            //            .Where(atr => atr.Equals(command))
            //           .ToString().Length > 0);

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