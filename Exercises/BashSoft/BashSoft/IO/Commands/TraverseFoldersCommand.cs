using BashSoft.Judge;
using BashSoft.Repository;
using System.Text.RegularExpressions;

namespace BashSoft.IO.Commands
{
    class TraverseFoldersCommand : Command
    {
        public TraverseFoldersCommand(Match match, Tester judge, StudentsRepository repository, IOManager inputOutputManager)
               : base(match, judge, repository, inputOutputManager)
        {
        }

        public override void Execute()
        {
            int depth = int.Parse($"0{base.Match.Groups[3].Value}");
            System.Console.WriteLine(depth);
            base.InputOutputManager.TraverseDirectory(depth);
        }
    }
}