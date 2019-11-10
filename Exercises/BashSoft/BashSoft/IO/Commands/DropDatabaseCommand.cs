using BashSoft.Judge;
using BashSoft.Repository;
using System.Text.RegularExpressions;

namespace BashSoft.IO.Commands
{
    class DropDatabaseCommand : Command
    {
        public DropDatabaseCommand(Match match, Tester judge, StudentsRepository repository, IOManager inputOutputManager)
               : base(match, judge, repository, inputOutputManager)
        {
        }

        public override void Execute()
        {
            base.Repository.UnloadDate();
            OutputWriter.WriteMessageOnNewLine("Database dropped!");
        }
    }
}