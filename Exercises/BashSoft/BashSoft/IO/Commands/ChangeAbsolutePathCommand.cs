using BashSoft.Judge;
using BashSoft.Repository;
using System.Text.RegularExpressions;

namespace BashSoft.IO.Commands
{
    public class ChangeAbsolutePathCommand : Command
    {
        public ChangeAbsolutePathCommand(Match match, Tester judge, StudentsRepository repository, IOManager inputOutputManager)
            : base(match, judge, repository, inputOutputManager)
        {
        }

        public override void Execute()
        {
            string absolutePath = this.Match.Groups[2].Value;

            base.InputOutputManager.ChangeDirectoryAbsolute(absolutePath);
        }
    }
}