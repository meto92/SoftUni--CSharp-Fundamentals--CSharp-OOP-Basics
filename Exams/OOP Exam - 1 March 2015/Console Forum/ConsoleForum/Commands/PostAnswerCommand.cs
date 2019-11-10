using System;
using ConsoleForum.Contracts;
using ConsoleForum.Entities.Posts;

namespace ConsoleForum.Commands
{
    public class PostAnswerCommand : AbstractCommand
    {
        public PostAnswerCommand(IForum forum) 
            : base(forum)
        { }

        public override void Execute()
        {
            string body = base.Data[1];

            if (!base.Forum.IsLogged)
            {
                throw new CommandException(Messages.NotLogged);
            }

            if (base.Forum.CurrentQuestion == null)
            {
                throw new CommandException(Messages.NoQuestionOpened);
            }

            int id = base.Forum.Answers.Count + 1;
            
            IAnswer answer = new Answer(id, body, base.Forum.CurrentUser);

            base.Forum.Answers.Add(answer);
            base.Forum.CurrentQuestion.Answers.Add(answer);

            base.Forum.Output.AppendLine(
                string.Format(Messages.PostAnswerSuccess, id));
        }
    }
}