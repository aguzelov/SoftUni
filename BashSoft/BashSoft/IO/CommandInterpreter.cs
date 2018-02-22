using BashSoft.Exceptions;
using BashSoft.IO.Commands;
using System;
using System.IO;

namespace BashSoft
{
    public class CommandInterpreter
    {
        private Tester judge;
        private StudentsRepository repository;
        private IOManager inputOutputIoManager;

        public CommandInterpreter(Tester judge, StudentsRepository repository, IOManager inputOutputIoManager)
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
                Command command = this.ParseCommand(input, data, commandName);
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

        private Command ParseCommand(string input, string[] data, string command)
        {
            switch (command)
            {
                case "open":
                    return new OpenFileCommand(input, data, this.judge, this.repository, this.inputOutputIoManager);

                case "mkdir":
                    return new MakeDirectoryCommand(input, data, this.judge, this.repository, this.inputOutputIoManager);

                case "ls":
                    return new TraverseFoldersCommand(input, data, this.judge, this.repository, this.inputOutputIoManager);

                case "cmp":
                    return new CompareFilesCommand(input, data, this.judge, this.repository, this.inputOutputIoManager);

                case "cdRel":
                    return new ChangeRelativePathCommand(input, data, this.judge, this.repository, this.inputOutputIoManager);

                case "cdAbs":
                    return new ChangeAbsolutePathCommand(input, data, this.judge, this.repository, this.inputOutputIoManager);

                case "readDb":
                    return new ReadDatabaseCommand(input, data, this.judge, this.repository, this.inputOutputIoManager);

                case "help":
                    return new GetHelpCommand(input, data, this.judge, this.repository, this.inputOutputIoManager);

                case ":q!":
                case "logout":
                case "exit":
                    return new CloseConsoleCommand(input, data, this.judge, this.repository, this.inputOutputIoManager);

                case "show":
                    return new ShowCourseCommand(input, data, this.judge, this.repository, this.inputOutputIoManager);

                case "filter":
                    return new PrintFilteredStudentsCommand(input, data, this.judge, this.repository, this.inputOutputIoManager);

                case "order":
                    return new PrintOrderedStudentsCommand(input, data, this.judge, this.repository, this.inputOutputIoManager);

                case "dropdb":
                    return new DropDatabaseCommand(input, data, this.judge, this.repository, this.inputOutputIoManager);

                case "download":
                //TODO: implement after functionality is implemented
                case "downloadAsynch":
                //TODO: implement after functionality is implemented
                default:
                    throw new InvalidCommandException(input);
            }
        }
    }
}