namespace Forum.App.UserInterface.ViewModels
{
    using Forum.App.Services;
    using Forum.Models;
    using System.Collections.Generic;

    public class PostViewModel : ViewModel
    {
        public PostViewModel()
            : base()
        { }

        public PostViewModel(Post post)
            : base(post.AuthorId, post.Content)
        {
            this.PostId = post.Id;
            this.Title = post.Title;
            this.Category = PostService.GetCategory(post.CategoryId).Name;
            this.Replies = PostService.GetPostReplies(post.Id);
        }

        public int PostId { get; set; }

        public string Title { get; set; }

        public string Category { get; set; }

        public IList<ReplyViewModel> Replies { get; set; }
    }
}