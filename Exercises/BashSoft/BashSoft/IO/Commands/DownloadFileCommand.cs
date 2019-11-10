using BashSoft.Judge;
using BashSoft.Repository;
using System.Text.RegularExpressions;

namespace BashSoft.IO.Commands
{
    class DownloadFileCommand : Command
    {
        public DownloadFileCommand(Match match, Tester judge, StudentsRepository repository, IOManager inputOutputManager)
               : base(match, judge, repository, inputOutputManager)
        {
        }

        public override void Execute()
        {
            string filePath = base.Match.Groups[2].Value;

            base.InputOutputManager.DownloadFile(filePath);
        }
    }
}