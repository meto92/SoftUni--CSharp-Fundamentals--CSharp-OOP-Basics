using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleForum.Contracts;
using ConsoleForum.Utility;

namespace ConsoleForum.Commands
{
    public class LoginCommand : AbstractCommand
    {
        public LoginCommand(IForum forum)
            : base(forum)
        { }

        public override void Execute()
        {
            IList<IUser> users = base.Forum.Users;
            string username = this.Data[1];
            string password = PasswordUtility.Hash(this.Data[2]);

            if (base.Forum.IsLogged)
            {
                throw new CommandException(Messages.AlreadyLoggedIn);
            }

            IUser user = users.Where(u => u.Username == username).FirstOrDefault();

            if (user == null ||
                user.Password != password)
            {
                throw new CommandException(Messages.InvalidLoginDetails);
            }

            base.Forum.Output.AppendLine(string.Format(
                Messages.LoginSuccess, user.Username));

            base.Forum.CurrentUser = user;
        }
    }
}