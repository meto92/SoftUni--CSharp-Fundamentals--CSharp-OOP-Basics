using BashSoft.Judge;
using BashSoft.Repository;
using System.Text.RegularExpressions;

namespace BashSoft.IO.Commands
{
    class CompareFilesCommand : Command
    {
        public CompareFilesCommand(Match match, Tester judge, StudentsRepository repository, IOManager inputOutputManager)
            : base(match, judge, repository, inputOutputManager)
        {
        }

        public override void Execute()
        {
            string path1 = base.Match.Groups[2].Value;
            string path2 = base.Match.Groups[4].Value;

            base.Judge.CompareContent(path1, path2);
        }
    }
}