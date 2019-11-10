using System;
using ConsoleForum.Contracts;

namespace ConsoleForum.Commands
{
    public class ExitCommand : AbstractCommand
    {
        public ExitCommand(IForum forum)
            : base(forum)
        { }

        public override void Execute()
        {
            Environment.Exit(0);
        }
    }
}