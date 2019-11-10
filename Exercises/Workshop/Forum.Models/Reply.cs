namespace Forum.Models
{
    public class Reply : Identifiable
    {
        private string content;
        private int authorId;
        private int postId;

        public Reply(int id, string content, int authorId, int postId)
            : base(id)
        {
            this.Content = content;
            this.AuthorId = authorId;
            this.PostId = postId;
        }

        public string Content
        {
            get => this.content;
            set => this.content = value;
        }

        public int AuthorId
        {
            get => this.authorId;
            set => this.authorId = value;
        }

        public int PostId
        {
            get => this.postId;
            set => this.postId = value;
        }
    }
}