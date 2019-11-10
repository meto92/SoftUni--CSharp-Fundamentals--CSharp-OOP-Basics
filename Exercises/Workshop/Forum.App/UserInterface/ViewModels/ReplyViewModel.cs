namespace Forum.App.UserInterface.ViewModels
{
    using Forum.Models;

    public class ReplyViewModel : ViewModel
    {
        public ReplyViewModel()
        { }

        public ReplyViewModel(Reply reply)
            : base(reply.AuthorId, reply.Content)
        { }
    }
}