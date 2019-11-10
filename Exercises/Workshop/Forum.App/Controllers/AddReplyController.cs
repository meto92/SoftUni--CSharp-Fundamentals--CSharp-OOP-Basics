namespace Forum.App.Controllers
{
    using System.Linq;
    using Forum.App.Controllers.Contracts;
    using Forum.App.Services;
    using Forum.App.UserInterface.Contracts;
    using Forum.App.UserInterface.Input;
    using Forum.App.UserInterface.ViewModels;
    using Forum.App.Views;

    public class AddReplyController : IController
    {
        private enum Command
        {
            Write,
            Post
        }

        private const int TEXT_AREA_WIDTH = 37;
        private const int TEXT_AREA_HEIGHT = 6;
        private const int POST_MAX_LENGTH = 220;

        private static int centerTop = Position.ConsoleCenter().Top;
        private static int centerLeft = Position.ConsoleCenter().Left;

        private TextArea textArea;

        public AddReplyController()
        {
            this.ResetReply();
        }

        public PostViewModel Post { get; private set; }

        public ReplyViewModel Reply { get; private set; }

        public bool HasError { get; private set; }

        public MenuState ExecuteCommand(int index)
        {
            switch ((Command) index)
            {
                case Command.Write:
                    this.textArea.Write();
                    this.Reply.Content = this.textArea.Lines.ToList();

                    return MenuState.AddReply;
                case Command.Post:
                    bool isReplyValid = PostService.TrySaveReply(this.Reply, this.Post.PostId);

                    if (!isReplyValid)
                    {
                        this.HasError = true;

                        return MenuState.Rerender;
                    }

                    return MenuState.ReplyAdded;
            }

            throw new InvalidCommandException();
        }

        public IView GetView(string userName)
        {
            this.Reply.Author = userName;
            
            return new AddReplyView(this.Post, this.Reply, this.textArea, this.HasError);
        }

        public void ResetReply()
        {
            this.HasError = false;
            this.Reply = new ReplyViewModel();

            int postContentLinesCount = this.Post?.Content.Count ?? 0;
            
            this.textArea = new TextArea(centerLeft - 18, centerTop - 6 + postContentLinesCount, TEXT_AREA_WIDTH, TEXT_AREA_HEIGHT, POST_MAX_LENGTH);
        }

        public void SetPostId(int postId)
        {
            this.Post = PostService.GetPostViewModel(postId);
            this.ResetReply();
        }
    }
}