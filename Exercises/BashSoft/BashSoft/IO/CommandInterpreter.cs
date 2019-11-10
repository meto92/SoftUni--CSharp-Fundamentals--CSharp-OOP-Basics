using System;
using System.Linq;
using BashSoft.Judge;
using BashSoft.Repository;
using BashSoft.IO.Commands;
using System.Text.RegularExpressions;

namespace BashSoft.IO
{
    public class CommandInterpreter
    {
        private Tester judge;
        private StudentsRepository repository;
        private IOManager inputOutputManager;

        public CommandInterpreter(Tester judge, StudentsRepository repository, IOManager inputOutputManager)
        {
            this.judge = judge;
            this.repository = repository;
            this.inputOutputManager = inputOutputManager;
        }

        private void TryFilterAndTake(Match match)
        {
            string courseName = match.Groups[2].Value;
            string filter = match.Groups[3].Value;
            string studentsToTakeStr = match.Groups[4].Value;

            if (int.TryParse(studentsToTakeStr, out int studentsToTake))
            {
                this.repository.FilterAndTake(courseName, filter, studentsToTake);
            }
            else
            {
                this.repository.FilterAndTake(courseName, filter);
            }
        }

        private Command ParseCommand(string input, string commandName)
        {
            if (!Patterns.PatternsByCommands.ContainsKey(commandName))
            {
                throw new CommandNotFoundExeption(commandName);
            }

            Match match = Patterns.PatternsByCommands[commandName].Match(input);

            if (!match.Success)
            {
                throw new InvalidCommandException(input);
            }

            switch (commandName)
            {
                case "open":
                    return new OpenFileCommand(match, this.judge, this.repository, this.inputOutputManager);
                case "mkdir":
                    return new MakeDirectoryCommand(match, this.judge, this.repository, this.inputOutputManager);
                case "ls":
                    return new TraverseFoldersCommand(match, this.judge, this.repository, this.inputOutputManager);
                case "cmp":
                    return new CompareFilesCommand(match, this.judge, this.repository, this.inputOutputManager);
                case "cdRel":
                    return new ChangePathRelativelyCommand(match, this.judge, this.repository, this.inputOutputManager);
                case "cdAbs":
                    return new ChangeAbsolutePathCommand(match, this.judge, this.repository, this.inputOutputManager);
                case "readDb":
                    return new ReadDatabaseCommand(match, this.judge, this.repository, this.inputOutputManager);
                case "show":
                    return new ShowCourseCommand(match, this.judge, this.repository, this.inputOutputManager);
                case "filter":
                    return new PrintFilteredStudentsCommand(match, this.judge, this.repository, this.inputOutputManager);
                case "order":
                    return new PrintOrderedStudentsCommand(match, this.judge, this.repository, this.inputOutputManager);
                case "download":
                    return new DownloadFileCommand(match, this.judge, this.repository, this.inputOutputManager);
                case "dropdb":
                    return new DropDatabaseCommand(match, this.judge, this.repository, this.inputOutputManager);
                case "help":
                    return new GetHelpCommand(match, this.judge, this.repository, this.inputOutputManager);
            }

            return null;
        }

        public void InterpretCommand(string input)
        {
            if (input == string.Empty)
            {
                return;
            }

            string commandName =
                input.Split(new[] { ' ', '\t' },
                    StringSplitOptions.RemoveEmptyEntries)
                .First();

            try
            {
                Command command = this.ParseCommand(input, commandName);
                command.Execute();
            }
            catch (Exception ex)
            {
                OutputWriter.DisplayException(ex.Message);
            }
        }
    }
}