using System;
using System.Diagnostics;
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
            string command = data[0];
            try
            {
                this.ParseCommand(input, data, command);
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
            catch (Exception e)
            {
                OutputWriter.DisplayException(e.Message);
            }
            
        }

        private void ParseCommand(string input, string[] data, string command)
        {
            switch (command)
            {
                case "open":
                    TryOpenFile(input, data);
                    break;
                case "mkdir":
                    TryCreateDirectory(input, data);
                    break;
                case "ls":
                    TryTraverseFolders(input, data);
                    break;
                case "cmp":
                    TryCompareFiles(input, data);
                    break;
                case "cdRel":
                    TryChangePathRelatively(input, data);
                    break;
                case "cdAbs":
                    TryChangePathAbsolute(input, data);
                    break;
                case "readDb":
                    TryReadDataBaseFromFile(input, data);
                    break;
                case "help":
                    TryGetHelp(input, data);
                    break;
                case ":q!":
                case "logout":
                case "exit":
                    Environment.Exit(0);
                    break;
                case "show":
                    TryShowWantedData(input, data);
                    break;
                case "filter":
                    TryFilterAndTake(input, data);
                    break;
                case "order":
                    TryOrderAndTake(input, data);
                    break;
                case "dropdb":
                    TryDropDb(input, data);
                    break;
                case "download":
                    //TODO: implement after functionality is implemented
                    break;
                case "downloadAsynch":
                    //TODO: implement after functionality is implemented
                    break;
                default:
                    DisplayInvalidCommandMessage(input);
                    break;
            }
        }

        private void TryDropDb(string input, string[] data)
        {
            if (data.Length != 1)
            {
                this.DisplayInvalidCommandMessage(input);
                return;
            }

            this.repository.UnloadData();
            OutputWriter.WriteMessageOnNewLine("Database dropped!");
        }

        private void TryOrderAndTake(string input, string[] data)
        {
            if (data.Length == 5)
            {
                string courseName = data[1];
                string orderBy = data[2].ToLower();
                string command = data[3].ToLower();
                string quantity = data[4].ToLower();

                TryParseParametersForOrderAndTake(command, orderBy, courseName, quantity);
            }
            else
            {
                DisplayInvalidCommandMessage(input);
            }
        }

        private void TryParseParametersForOrderAndTake(string command, string orderBy, string courseName, string quantity)
        {
            if (command == "take")
            {
                if (quantity == "all")
                {
                    this.repository.OrderAndTake(courseName, orderBy);
                }
                else
                {
                    int studentsToTake;
                    bool hasParsed = int.TryParse(quantity, out studentsToTake);
                    if (hasParsed)
                    {
                        this.repository.OrderAndTake(courseName, orderBy, studentsToTake);
                    }
                    else
                    {
                        OutputWriter.DisplayException(ExceptionMessages.InvalidTakeQuantityParameter);
                    }
                }
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidTakeCommand);
            }
        }

        private void TryFilterAndTake(string input, string[] data)
        {
            if (data.Length == 5)
            {
                string courseName = data[1];
                string filter = data[2].ToLower();
                string command = data[3].ToLower();
                string quantity = data[4].ToLower();

                TryParseParametersFromFilterAndTake(command, quantity, courseName, filter);
            }
            else
            {
                DisplayInvalidCommandMessage(input);
            }
        }

        private void TryParseParametersFromFilterAndTake(string command, string quantity, string courseName, string filter)
        {
            if (command == "take")
            {
                if (quantity == "all")
                {
                    this.repository.FilterAndTake(courseName, filter);
                }
                else
                {
                    int studentsToTake;
                    bool hasParsed = int.TryParse(quantity, out studentsToTake);
                    if (hasParsed)
                    {
                        this.repository.FilterAndTake(courseName, filter, studentsToTake);
                    }
                    else
                    {
                        OutputWriter.DisplayException(ExceptionMessages.InvalidTakeQuantityParameter);
                    }
                }
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidTakeCommand);
            }
        }

        private void TryShowWantedData(string input, string[] data)
        {
            if (data.Length == 2)
            {
                string courseName = data[1];
                this.repository.GetAllStudentsFromCourse(courseName);
            }
            else if (data.Length == 3)
            {
                string courseName = data[1];
                string username = data[2];
                this.repository.GetStudentScoresFromCourse(courseName, username);
            }
            else
            {
                DisplayInvalidCommandMessage(input);
            }
        }

        private void TryOpenFile(string input, string[] data)
        {
            if (data.Length == 2)
            {
                string fileName = data[1];
                Process.Start(SessionData.currentPath + "\\" + fileName);
            }
            else
            {
                DisplayInvalidCommandMessage(input);
            }
        }

        private void TryCreateDirectory(string input, string[] data)
        {
            if (data.Length == 2)
            {
                string folderName = data[1];
                this.inputOutputIoManager.CreateDirectoryInCurrentFolder(folderName);
            }
            else
            {
                DisplayInvalidCommandMessage(input);
            }
        }

        private void TryTraverseFolders(string input, string[] data)
        {
            if (data.Length == 1)
            {
                this.inputOutputIoManager.TraverseDirectory(0);
            }
            else if (data.Length == 2)
            {
                int depth;
                bool hasParsed = int.TryParse(data[1], out depth);
                if (hasParsed)
                {
                    this.inputOutputIoManager.TraverseDirectory(depth);
                }
                else
                {
                    OutputWriter.DisplayException(ExceptionMessages.UnableToParseNumber);
                }
            }
            else
            {
                DisplayInvalidCommandMessage(input);
            }
        }

        private void TryCompareFiles(string input, string[] data)
        {
            if (data.Length == 3)
            {
                string firstPath = data[1];
                string secondPath = data[2];

                this.judge.CompareContent(firstPath, secondPath);
            }
            else
            {
                DisplayInvalidCommandMessage(input);
            }
        }

        private void TryChangePathRelatively(string input, string[] data)
        {
            if (data.Length == 2)
            {
                string relPath = data[1];
                this.inputOutputIoManager.ChangeCurrentDirectoryRelative(relPath);
            }
            else
            {
                DisplayInvalidCommandMessage(input);
            }
        }

        private void TryChangePathAbsolute(string input, string[] data)
        {
            if (data.Length == 2)
            {
                string absolutePath = data[1];
                this.inputOutputIoManager.ChangeCurrentDirectoryAbsolute(absolutePath);
            }
            else
            {
                DisplayInvalidCommandMessage(input);
            }
        }

        private void TryReadDataBaseFromFile(string input, string[] data)
        {
            if (data.Length == 2)
            {
                string fileName = data[1];
                this.repository.LoadData(fileName);
            }
            else
            {
                DisplayInvalidCommandMessage(input);
            }
        }

        private void TryGetHelp(string input, string[] data)
        {
            OutputWriter.WriteMessageOnNewLine($"{new string('_', 100)}");
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "make directory - mkdir: path "));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "traverse directory - ls: depth "));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "comparing files - cmp: path1 path2"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "change directory - changeDirREl:relative path"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "change directory - changeDir:absolute path"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "read students data base - readDb: path"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "filter {courseName} excelent/average/poor  take 2/5/all students - filterExcelent (the output is written on the console)"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "order increasing students - order {courseName} ascending/descending take 20/10/all (the output is written on the console)"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "download file - download: path of file (saved in current directory)"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "download file asinchronously - downloadAsynch: path of file (save in the current directory)"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "get help – help"));
            OutputWriter.WriteMessageOnNewLine($"{new string('_', 100)}");
            OutputWriter.WriteEmptyLine();
        }

        private void DisplayInvalidCommandMessage(string input)
        {
            OutputWriter.DisplayException($"The command '{input}' is invalid");
        }
    }
}