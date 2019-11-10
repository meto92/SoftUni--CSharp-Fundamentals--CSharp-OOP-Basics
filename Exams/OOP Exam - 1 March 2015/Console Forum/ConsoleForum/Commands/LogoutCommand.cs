using ConsoleForum.Contracts;

namespace ConsoleForum.Commands
{
    public class LogoutCommand : AbstractCommand
    {
        public LogoutCommand(IForum forum) 
            : base(forum)
        { }

        public override void Execute()
        {
            if (!base.Forum.IsLogged)
            {
                throw new CommandException(Messages.NotLogged);
            }

            this.Forum.Output.AppendLine(Messages.LogoutSuccess);

            base.Forum.CurrentUser = null;
            base.Forum.CurrentQuestion = null;
        }
    }
}