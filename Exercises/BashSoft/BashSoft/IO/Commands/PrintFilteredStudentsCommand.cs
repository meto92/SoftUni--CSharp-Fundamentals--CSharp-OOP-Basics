using BashSoft.Judge;
using BashSoft.Repository;
using System.Text.RegularExpressions;

namespace BashSoft.IO.Commands
{
    class PrintFilteredStudentsCommand : Command
    {
        public PrintFilteredStudentsCommand(Match match, Tester judge, StudentsRepository repository, IOManager inputOutputManager)
               : base(match, judge, repository, inputOutputManager)
        {
        }

        public override void Execute()
        {
            string courseName = base.Match.Groups[2].Value;
            string filter = base.Match.Groups[3].Value;
            string studentsToTakeStr = base.Match.Groups[4].Value;

            if (int.TryParse(studentsToTakeStr, out int studentsToTake))
            {
                base.Repository.FilterAndTake(courseName, filter, studentsToTake);
            }
            else
            {
                base.Repository.FilterAndTake(courseName, filter);
            }
        }
    }
}