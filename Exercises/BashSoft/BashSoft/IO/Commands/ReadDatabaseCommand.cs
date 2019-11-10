using BashSoft.Judge;
using BashSoft.Repository;
using System.Text.RegularExpressions;

namespace BashSoft.IO.Commands
{
    class ReadDatabaseCommand : Command
    {
        public ReadDatabaseCommand(Match match, Tester judge, StudentsRepository repository, IOManager inputOutputManager)
               : base(match, judge, repository, inputOutputManager)
        {
        }

        public override void Execute()
        {
            string fileName = base.Match.Groups[2].Value;

            base.Repository.LoadData(fileName);
        }
    }
}