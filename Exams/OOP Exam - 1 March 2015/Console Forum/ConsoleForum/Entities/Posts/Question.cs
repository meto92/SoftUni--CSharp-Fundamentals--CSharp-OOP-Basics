using ConsoleForum.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleForum.Entities.Posts
{
    public class Question : Post, ICustomQuestion
    {
        private List<IAnswer> answers;

        public Question(int id, string body, IUser author, string title) 
            : base(id, body, author)
        {
            this.Title = title;
            this.answers = new List<IAnswer>();
        }

        public string Title { get; set; }

        public IList<IAnswer> Answers => this.answers;

        public IAnswer BestAnswer { get; set; }

        private void AppendAnswers(StringBuilder sb)
        {
            sb.AppendLine("Answers:");

            if (this.BestAnswer != null)
            {
                sb.AppendLine("********************");
                sb.AppendLine(this.BestAnswer.ToString());
                sb.AppendLine("********************");
            }

            foreach (IAnswer answer in this.Answers
                .Where(a => a.Id != this.BestAnswer?.Id)
                .OrderBy(a => a.Id))
            {
                sb.AppendLine(answer.ToString());
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"[ Question ID: {this.Id} ]");
            sb.AppendLine($"Posted by: {this.Author.Username}");
            sb.AppendLine($"Question Title: {this.Title}");
            sb.AppendLine($"Question Body: {this.Body}");
            sb.AppendLine($"====================");

            if (this.Answers.Count == 0)
            {
                sb.Append(Messages.NoAnswers);
            }
            else
            {
                AppendAnswers(sb);
            }

            return sb.ToString().TrimEnd();
        }
    }
}