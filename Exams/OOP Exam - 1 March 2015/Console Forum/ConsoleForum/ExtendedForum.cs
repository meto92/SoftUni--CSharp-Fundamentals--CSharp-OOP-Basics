using System;
using System.Collections.Generic;
using System.Linq;

using ConsoleForum.Contracts;
using ConsoleForum.Entities.Posts;

namespace ConsoleForum
{
    public class ExtendedForum : Forum
    {
        private bool addHeaders;

        public ExtendedForum(bool addHeaders)
        {
            this.addHeaders = addHeaders;
        }

        public new IList<ICustomQuestion> Questions { get; private set; }

        public new ICustomQuestion CurrentQuestion { get; private set; }

        public override void Run()
        {
            base.Setup();

            while (this.HasStarted)
            {
                if (!this.addHeaders)
                {
                    this.ExecuteCommandLoop();

                    continue;
                }

                int hotQuestionsCount = 1,
                activeUsersCount = base.Answers
                    .GroupBy(answer => answer.Author)
                    .Count();

                base.Output.Clear();
                base.Output.AppendLine("~~~~~~~~~~~~~~~~~~~~");

                if (base.IsLogged)
                {
                    base.Output.AppendLine($"Welcome, {base.CurrentUser.Username}!");
                }
                else
                {
                    base.Output.AppendLine("Hey stranger, care to login/register?");
                }

                base.Output.AppendLine($"Hot questions: {hotQuestionsCount}, Active users: {activeUsersCount}");
                base.Output.AppendLine("~~~~~~~~~~~~~~~~~~~~");

                Console.Write(this.Output);

                this.ExecuteCommandLoop();
            }
        }
    }
}