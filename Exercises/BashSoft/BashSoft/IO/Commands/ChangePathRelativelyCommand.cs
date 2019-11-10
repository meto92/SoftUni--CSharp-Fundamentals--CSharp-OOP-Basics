using System.Linq;
using BashSoft.Judge;
using BashSoft.Repository;
using System.Text.RegularExpressions;

namespace BashSoft.IO.Commands
{
    class ChangePathRelativelyCommand : Command
    {
        public ChangePathRelativelyCommand(Match match, Tester judge, StudentsRepository repository, IOManager inputOutputManager)
            : base(match, judge, repository, inputOutputManager)
        {
        }

        private string FixSlashes(string path)
        {
            return Regex.Replace(path, @"[\\\/]+", "\\");
        }

        private void TryChangePathRelatively(Match match)
        {
            string matchValue = match.Value;
            int[] indices = { matchValue.IndexOf(' '), matchValue.IndexOf('\t') };
            int index = indices.Where(x => x != -1).First();
            string relativePath = matchValue.Substring(index).Trim();

            base.InputOutputManager.ChangeDirectoryRelative(FixSlashes(relativePath));
        }

        public override void Execute()
        {
            this.TryChangePathRelatively(base.Match);
        }
    }
}