namespace Forum.App.Controllers
{
    using System.Linq;
    using Forum.App.Controllers.Contracts;
    using Forum.App.Services;
    using Forum.App.UserInterface.Contracts;
    using Forum.App.Views;

    public class CategoryController : IController, IPaginationController
    {
        private enum Command
        {
            Back = 0,
            ViewCategory = 1,
            PreviousPage = 11,
            NextPage = 12
        }

        public const int PAGE_OFFSET = 10;
        private const int COMMAND_COUNT = PAGE_OFFSET + 3;

        private string[] postTitles;

        public CategoryController()
        {
            this.CurrentPage = 0;
            this.SetCategory(0);
        }

        private int LastPage => this.postTitles.Length / 11;

        public int CurrentPage { get; set; }

        private bool IsFirstPage => this.CurrentPage == 0;

        private bool IsLastPage => this.CurrentPage == this.LastPage;

        public int CategoryId { get; set; }

        public MenuState ExecuteCommand(int index)
        {
            if (index > 1 && index < 11)
            {
                index = 1;
            }

            switch ((Command)index)
            {
                case Command.Back:
                    return MenuState.Back;
                case Command.ViewCategory:
                    return MenuState.ViewPost;
                case Command.PreviousPage:
                    this.ChangePage(false);

                    return MenuState.Rerender;
                case Command.NextPage:
                    this.ChangePage();

                    return MenuState.Rerender;
            }

            throw new InvalidCommandException();
        }

        private void GetPosts()
        {
            this.postTitles = PostService.GetPostsByCategory(this.CategoryId)
                .Skip(this.CurrentPage * PAGE_OFFSET)
                .Take(PAGE_OFFSET)
                .Select(post => post.Title)
                .ToArray();
        }

        public IView GetView(string userName)
        {
            this.GetPosts();
            
            string categoryName = PostService.GetCategory(this.CategoryId).Name;
            
            return new CategoryView(categoryName, this.postTitles, this.IsFirstPage, this.IsLastPage);
        }

        public void SetCategory(int categoryId)
        {
            this.CategoryId = categoryId;
        }

        private void ChangePage(bool forward = true)
        {
            this.CurrentPage += forward ? 1 : -1;
            GetPosts();
        }        
    }
}