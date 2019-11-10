using ConsoleForum.Contracts;
using System.Collections.Generic;

namespace ConsoleForum.Entities.Users
{
    public abstract class AbstractUser : IUser
    {
        public AbstractUser(int id, string name, string password, string email)
        {
            this.Id = id;
            this.Username = name;
            this.Password = password;
            this.Email = email;
            this.Questions = new List<IQuestion>();
        }

        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public IList<IQuestion> Questions { get; private set; }
    }
}
