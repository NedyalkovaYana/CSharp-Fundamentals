using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using IntegrationTests.Interfaces;

namespace IntegrationTests.Models
{
    public class Category : ICategory
    {
        private const string ExceptionMessage = "Cannot create category without name!";
        private string name;
        private IList<IUser> users;
        private IList<ICategory> childCategories;
        private ICategory parent;

        public Category(string name)
        {
            this.Name = name;
            this.Users = new List<IUser>();
            this.childCategories = new List<ICategory>();
            this.Parent = parent;
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (value == String.Empty || string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessage);
                }

                this.name = value;
            }
        }

        public ICategory Parent
        {
            get { return this.parent; }

            private set { this.parent = value; }
        }

        public IList<IUser> Users
        {
            get { return this.users; }
            private set { this.users = value; }
        }
        public IList<ICategory> ChildCategories => 
                                        new ReadOnlyCollection<ICategory>(this.childCategories);

        public void AddChild(ICategory child)
        {
            this.childCategories.Add(child);
            child.SetParent(this);
        }

        public void MoveUsersToParent()
        {
            if (this.Parent == null)
            {
                return;
            }
            foreach (var user in this.Users)
            {
                this.Parent.AddUser(user);
            }
        }

        public void RemoveChild(string name)
        {
            var categoryToRemove = this.ChildCategories.FirstOrDefault(ch => ch.Name == name);
            this.ChildCategories?.Remove(categoryToRemove);
        }

        public void AddUser(IUser user)
        {
            this.Users.Add(user);
            user.AddCategory(this);
        }

        public void SetParent(ICategory category)
        {
            this.Parent = category;
        }
    }
}

