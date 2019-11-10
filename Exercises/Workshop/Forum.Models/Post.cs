using System.Collections.Generic;

namespace Forum.Models
{
    public class Post : Identifiable
    {
        private string title;
        private string content;
        private int categoryId;
        private int authorId;
        private List<int> replyIds;

        public Post(int id, string title, string content, int categoryId, int authorId, IEnumerable<int> replyIds = null)
            : base(id)
        {
            this.Title = title;
            this.Content = content;
            this.CategoryId = categoryId;
            this.AuthorId = authorId;
            this.replyIds = new List<int>();
            this.replyIds.AddRange(replyIds ?? new List<int>());
        }
        
        public string Title
        {
            get => this.title;
            set => this.title = value;
        }

        public string Content
        {
            get => this.content;
            set => this.content = value;
        }

        public int CategoryId
        {
            get => this.categoryId;
            set => this.categoryId = value;
        }

        public int AuthorId
        {
            get => this.authorId;
            set => this.authorId = value;
        }

        public ICollection<int> ReplyIds => this.replyIds;
    }
}