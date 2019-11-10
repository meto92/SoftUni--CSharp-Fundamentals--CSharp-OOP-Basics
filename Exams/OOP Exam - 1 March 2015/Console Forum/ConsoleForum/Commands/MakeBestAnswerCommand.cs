using System.Linq;

using ConsoleForum.Contracts;
using ConsoleForum.Entities.Posts;
using ConsoleForum.Entities.Users;

namespace ConsoleForum.Commands
{
    public class MakeBestAnswerCommand : AbstractCommand
    {
        public MakeBestAnswerCommand(IForum forum) 
            : base(forum)
        { }

        public override void Execute()
        {
            int id = int.Parse(base.Data[1]);

            if (!base.Forum.IsLogged)
            {
                throw new CommandException(Messages.NotLogged);
            }

            ICustomQuestion currentQuestion = base.Forum.CurrentQuestion as ICustomQuestion;
            //IQuestion question = base.Forum.CurrentQuestion;
            //ICustomQuestion currentQuestion = new Question(
            //    question.Id,
            //    question.Body,
            //    question.Author,
            //    question.Title);

            if (currentQuestion == null)
            {
                throw new CommandException(Messages.NoQuestionOpened);
            }

            IAnswer answer = base.Forum
                .CurrentQuestion
                .Answers
                .Where(a => a.Id == id)
                .FirstOrDefault();

            if (answer == null)
            {
                throw new CommandException(Messages.NoAnswer);
            }

            bool isCurrentUserAuthor = base.Forum.CurrentQuestion.Author.Id == base.Forum.CurrentUser.Id;
            bool isCurrentUserAdmin = base.Forum.CurrentUser.GetType() == typeof(Administrator);

            if (!isCurrentUserAuthor && !isCurrentUserAdmin)
            {
                throw new CommandException(Messages.NoPermission);
            }
            
            currentQuestion.BestAnswer = answer;

            base.Forum.Output.AppendLine(
                string.Format(Messages.BestAnswerSuccess, id));
        }
    }
}