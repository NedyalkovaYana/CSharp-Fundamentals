using System.Linq;
using Forum.App.Services;
using Forum.App.Views;

namespace Forum.App.Controllers
{
    using System;

    using Forum.App.Controllers.Contracts;
    using Forum.App.UserInterface.Contracts;

    public class CategoryController : IController, IPaginationController
    {
        public const int PAGE_OFFSET = 10;
        private const int COMMAND_COUNT = PAGE_OFFSET + 3;

        private bool IsFirstPage => this.CurrentPage == 0;
        private bool IsLastPage => this.CurrentPage == LastPage;
        private enum Command
        {
            Back = 0,
            ViewCategory = 1,
            PreviousPage = 11,
            NextPage = 12
        }

        public CategoryController()
        {
            this.CurrentPage = 0;
            this.SetCategory(0);
        }
        public int CurrentPage { get; set; }

        private string[] PostTitles { get; set; }
        private int LastPage => this.PostTitles.Length / 11;

        public int CategoryId { get; private set; }


        public MenuState ExecuteCommand(int index)
        {
            if (index > 1 && index < 11)
            {
                index = 1;
            }

            switch ((CategoriesController.Command)index)
            {
                case CategoriesController.Command.Back:
                    return MenuState.Back;
                case CategoriesController.Command.PreviousPage:
                    this.ChangePage(false);
                    return MenuState.Rerender;
                case CategoriesController.Command.NextPage:
                    this.ChangePage();
                    return MenuState.Rerender;
                case CategoriesController.Command.ViewCategory:
                    return MenuState.OpenCategory;

            }

            throw new InvalidOperationException();
        }

        public IView GetView(string userName)
        {
            GetPosts();
            string categoryName = PostService.GetCategory(this.CategoryId).Name;
            return new CategoryView(categoryName, this.PostTitles, this.IsFirstPage, this.IsLastPage);
        }

        public void SetCategory(int categoryId)
        {
            this.CategoryId = categoryId;
        }

        private void ChangePage(bool forward = true)
        {
            CurrentPage += forward ? 1 : -1;
        }

        private void GetPosts()
        {
            var allCategoryPosts = PostService.GetPostByCategory(CategoryId);

            this.PostTitles = allCategoryPosts
                .Skip(this.CurrentPage * PAGE_OFFSET)
                .Take(PAGE_OFFSET)
                .Select(p => p.Title)
                .ToArray();
        }
    }
}
