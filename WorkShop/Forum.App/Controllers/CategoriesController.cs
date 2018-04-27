using System.Linq;
using System.Runtime.CompilerServices;
using Forum.App.Services;
using Forum.App.Views;

namespace Forum.App.Controllers
{
    using System;

    using Forum.App.Controllers.Contracts;
    using Forum.App.UserInterface.Contracts;

    public class CategoriesController : IController, IPaginationController
    {
        public const int PAGE_OFFSET = 10;
        private const int COMMAND_COUNT = PAGE_OFFSET + 3;

        public enum Command
        {
            Back = 0,
            ViewCategory = 1,
            PreviousPage = 11,
            NextPage = 12
        }

        public int CurrentPage { get; set;}

        private string[] AllCategoryNames { get; set; }
        private string[] CurrentPageCategories { get; set; }

        private int LastPage => this.AllCategoryNames.Length / (PAGE_OFFSET + 1);

        private bool IsFirstPage => this.CurrentPage == 0;
        private bool IsLastPage => this.CurrentPage == LastPage;

        public CategoriesController()
        {
            CurrentPage = 0;
            LoadCategories();
        }
        private void ChangePage(bool forward = true)
        {
            CurrentPage += forward ? 1 : -1;
        }
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
                case Command.PreviousPage:
                    this.ChangePage(false);
                    return MenuState.Rerender;
                case Command.NextPage:
                    this.ChangePage();
                    return MenuState.Rerender;
                case Command.ViewCategory:
                    return MenuState.OpenCategory;

            }

            throw new InvalidOperationException();
        }

        public IView GetView(string userName)
        {
            LoadCategories();
            return new CategoriesView(this.CurrentPageCategories, IsFirstPage, IsLastPage);
        }

        private void LoadCategories()
        {
            AllCategoryNames = PostService.GetAllCategoryNames();
            CurrentPageCategories = AllCategoryNames
                .Skip(CurrentPage * PAGE_OFFSET)
                .Take(PAGE_OFFSET)
                .ToArray();
        }
    }
}
