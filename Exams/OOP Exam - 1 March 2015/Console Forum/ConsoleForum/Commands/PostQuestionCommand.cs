using System;
using ConsoleForum.Contracts;
using ConsoleForum.Entities.Posts;

namespace ConsoleForum.Commands
{
    public class PostQuestionCommand : AbstractCommand
    {
        public PostQuestionCommand(IForum forum) 
            : base(forum)
        { }

        public override void Execute()
        {
            string title = base.Data[1];
            string body = base.Data[2];

            if (!base.Forum.IsLogged)
            {
                throw new CommandException(Messages.NotLogged);
            }

            int id = base.Forum.Questions.Count + 1;

            IQuestion question = new Question(id, body, base.Forum.CurrentUser, title);

            base.Forum.Output.AppendLine(
                string.Format(Messages.PostQuestionSuccess, id));

            base.Forum.Questions.Add(question);
        }
    }
}