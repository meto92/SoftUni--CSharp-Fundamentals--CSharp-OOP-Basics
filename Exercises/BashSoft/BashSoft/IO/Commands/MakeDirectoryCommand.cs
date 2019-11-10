using BashSoft.Judge;
using BashSoft.Repository;
using System.Text.RegularExpressions;

namespace BashSoft.IO.Commands
{
    class MakeDirectoryCommand : Command
    {
        public MakeDirectoryCommand(Match match, Tester judge, StudentsRepository repository, IOManager inputOutputManager)
               : base(match, judge, repository, inputOutputManager)
        {
        }

        public override void Execute()
        {
            string folderName = base.Match.Groups[2].Value;

            base.InputOutputManager.CreateDirectoryInCurrentFolder(folderName);
        }
    }
}