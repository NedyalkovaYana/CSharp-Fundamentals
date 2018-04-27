using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IntegrationTests.Interfaces;
using IntegrationTests.Models;

namespace IntegrationTests
{
    public class CategoryController
    {
        private HashSet<ICategory> categories;

        public CategoryController()
        {
            this.categories = new HashSet<ICategory>();
        }

        public CategoryController(IEnumerable<string> names)
            :this()
        {
            foreach (var name in names)
            {
                this.AddCategory(name);
            }
        }

        public void AddCategory(string name)
        {
            if (this.categories.Any(c => c.Name == name || c.ChildCategories
                                                                .Any(ch => ch.Name == name)))
            {
                return;
            }

            this.categories.Add(new Category(name));
        }

        public void AddCategory(IEnumerable<string> names)
        {
            foreach (var name in names)
            {
                this.AddCategory(name);
            }
        }

        public void RemoveCategory(string name)
        {
            var categoryToRemove = this.categories.FirstOrDefault(c => c.Name == name);
            if (categoryToRemove == null)
            {
                foreach (var category in this.categories)
                {
                    if ((categoryToRemove == category.ChildCategories
                        .FirstOrDefault(c => c.Name == name)) != null)
                    {
                        break;
                    }
                }
            }

            if (categoryToRemove == null)
            {
                return;
            }

            categoryToRemove.MoveUsersToParent();
            this.RemoveCategoryFromUsersLists(categoryToRemove);
            this.MoveChildrenCategoriesToParent(categoryToRemove);

            if (categoryToRemove.Parent == null)
            {
                this.categories.Remove(categoryToRemove);
            }
            else
            {
                categoryToRemove.Parent.RemoveChild(categoryToRemove.Name);
            }
        }

        public void RemoveCategory(IEnumerable<string> names)
        {
            foreach (var name in names)
            {
                this.RemoveCategory(name);
            }
        }

        public void AddChild(ICategory parent, string childName) =>
                                                       parent.AddChild(new Category(childName));

        public void AddUser(ICategory category, IUser user) => category.AddUser(user);

        private void MoveChildrenCategoriesToParent(ICategory categotyToRemove)
        {
            if (categotyToRemove.Parent == null)
            {
                foreach (var category in categotyToRemove.ChildCategories)
                {
                    this.categories.Add(category);
                }

                return;                
            }

            foreach (var child in categotyToRemove.ChildCategories)
            {
                categotyToRemove.Parent.AddChild(child);
            }
        }

        private void RemoveCategoryFromUsersLists(ICategory categoryToRemove)
        {
            foreach (var user in categoryToRemove.Users)
            {
                user.RemoveCategory(categoryToRemove);
            }
        }
    }
}
