using BashSoft.Judge;
using BashSoft.Repository;
using System.Text.RegularExpressions;

namespace BashSoft.IO.Commands
{
    class ShowCourseCommand : Command
    {
        public ShowCourseCommand(Match match, Tester judge, StudentsRepository repository, IOManager inputOutputManager)
               : base(match, judge, repository, inputOutputManager)
        {
        }

        public override void Execute()
        {
            string courseName = base.Match.Groups[2].Value;
            string username = base.Match.Groups[4].Value;

            if (username != string.Empty)
            {
                base.Repository.GetStudentScoresFromCourse(courseName, username);
            }
            else
            {
                base.Repository.GetAllStudentsFromCourse(courseName);
            }
        }
    }
}