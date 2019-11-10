using System;
using ConsoleForum.Contracts;

namespace ConsoleForum.Entities.Posts
{
    public class AbstractAnswer : Post
    {
        public AbstractAnswer(int id, string body, IUser author)
            : base(id, body, author)
        { }

        public override string ToString()
        {
            string result = string.Concat(
                $"[ Answer ID: {base.Id} ]",
                Environment.NewLine,
                $"Posted by: {base.Author.Username}",
                Environment.NewLine,
                $"Answer Body: {base.Body}",
                Environment.NewLine,
                "--------------------");

            return result;
        }
    }
}