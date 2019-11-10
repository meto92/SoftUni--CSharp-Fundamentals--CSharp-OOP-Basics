using ConsoleForum.Contracts;
using System.Text;

namespace ConsoleForum.Entities.Posts
{
    public class BestAnswer : AbstractAnswer
    {
        public BestAnswer(int id, string body, IUser author) 
            : base(id, body, author)
        { }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("********************");
            sb.AppendLine(base.ToString());
            sb.Append("********************");

            return sb.ToString();
        }
    }
}