using System.IO;
using BashSoft.Judge;
using System.Diagnostics;
using BashSoft.Repository;
using System.Text.RegularExpressions;

namespace BashSoft.IO.Commands
{
    class OpenFileCommand : Command
    {
        public OpenFileCommand(Match match, Tester judge, StudentsRepository repository, IOManager inputOutputManager)
            : base(match, judge, repository, inputOutputManager)
        {
        }

        public override void Execute()
        {
            string fileName = base.Match.Groups[2].Value;
            string filePath = $"{SessionData.currentPath}\\{fileName}";

            if (Directory.Exists(filePath))
            {
                OutputWriter.WriteMessageOnNewLine("You are trying to open directory. File is expected.");
                return;
            }

            if (!File.Exists(filePath))
            {
                throw new InvalidPathException();
            }

            Process.Start(filePath);
        }
    }
}