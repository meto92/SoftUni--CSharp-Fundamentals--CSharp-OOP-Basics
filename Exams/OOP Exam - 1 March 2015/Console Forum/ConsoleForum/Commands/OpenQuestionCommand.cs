using System.Linq;

using ConsoleForum.Contracts;

namespace ConsoleForum.Commands
{
    class OpenQuestionCommand : AbstractCommand
    {
        public OpenQuestionCommand(IForum forum)
            : base(forum)
        { }

        public override void Execute()
        {
            int id = int.Parse(base.Data[1]);
            
            IQuestion question = base.Forum.Questions
                .Where(q => q.Id == id)
                .FirstOrDefault();
            
            if (question == null)
            {
                throw new CommandException(Messages.NoQuestion);
            }

            base.Forum.CurrentQuestion = question;
            
            base.Forum.Output.AppendLine(question.ToString());
        }
    }
}
