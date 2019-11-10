using System.Text;

using ConsoleForum.Contracts;

namespace ConsoleForum.Commands
{
    public class ShowQuestionsCommand : AbstractCommand
    {
        public ShowQuestionsCommand(IForum forum)
            : base(forum)
        { }

        public override void Execute()
        {
            StringBuilder result = new StringBuilder();

            if (base.Forum.Questions.Count == 0)
            {
                result.Append(Messages.NoQuestions);
            }

            foreach (IQuestion question in base.Forum.Questions)
            {
                result.AppendLine(question.ToString());
            }

            base.Forum.Output.AppendLine(result.ToString().TrimEnd());
        }
    }
}