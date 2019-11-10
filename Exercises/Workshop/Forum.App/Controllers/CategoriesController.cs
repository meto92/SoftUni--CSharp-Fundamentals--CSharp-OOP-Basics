namespace Forum.App.Controllers
{
    using System;
    using System.Linq;
    using Forum.App.Controllers.Contracts;
    using Forum.App.Services;
    using Forum.App.UserInterface.Contracts;
    using Forum.App.Views;

    public class CategoriesController : IController, IPaginationController
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

        private string[] allCategoryNames;
        private string[] currentPageCategories;

        public CategoriesController()
        {
            this.CurrentPage = 0;
            this.LoadCategories();
        }

        public int CurrentPage { get; set; }

        private int LastPage => this.allCategoryNames.Length / (PAGE_OFFSET + 1);

        private bool IsFirstPage => this.CurrentPage == 0;

        private bool IsLastPage => this.CurrentPage == this.LastPage;

        private void ChangePage(bool forward = true)
        {
            this.CurrentPage += forward ? 1 : -1;
        }

        public MenuState ExecuteCommand(int index)
        {
            if (index > 1 && index < 11)
            {
                index = 1;
            }

            switch ((Command) index)
            {
                case Command.Back:
                    return MenuState.Back;
                case Command.ViewCategory:
                    return MenuState.OpenCategory;
                case Command.PreviousPage:
                    this.ChangePage(false);

                    return MenuState.Rerender;
                case Command.NextPage:
                    this.ChangePage();

                    return MenuState.Rerender;
            }

            throw new InvalidCommandException();
        }

        private void LoadCategories()
        {
            this.allCategoryNames = PostService.GetAllGategoryNames();

            this.currentPageCategories = this.allCategoryNames
                .Skip(this.CurrentPage * PAGE_OFFSET)
                .Take(PAGE_OFFSET)
                .ToArray();
        }

        public IView GetView(string userName)
        {
            this.LoadCategories();

            return new CategoriesView(this.currentPageCategories, this.IsFirstPage, this.IsLastPage);
        }
    }
}