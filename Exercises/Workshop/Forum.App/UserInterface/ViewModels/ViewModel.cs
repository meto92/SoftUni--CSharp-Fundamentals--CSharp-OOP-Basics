using Forum.App.Services;
using System.Collections.Generic;
using System.Linq;

namespace Forum.App.UserInterface.ViewModels
{
    public abstract class ViewModel
    {
        protected const int LINE_LENGHT = 37;

        protected ViewModel()
        {
            this.Content = new List<string>();
        }

        protected ViewModel(int authorId, string content)
        {
            this.Author = UserService.GetUser(authorId).Username;
            this.Content = this.GetLines(content);
        }

        public string Author { get; set; }

        public IList<string> Content { get; set; }

        protected IList<string> GetLines(string content)
        {
            IList<string> lines = new List<string>();

            for (int i = 0; i < content.Length; i += LINE_LENGHT)
            {
                char[] lineChars = content.Skip(i).Take(LINE_LENGHT).ToArray();
                string line = new string(lineChars);

                lines.Add(line);
            }

            return lines;
        }
    }
}