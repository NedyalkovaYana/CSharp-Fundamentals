using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IntegrationTests.Interfaces;

namespace IntegrationTests.Models
{
    public class User : IUser
    {
        private string name;
        private HashSet<ICategory> categories;

        public User(string name)
        {
            this.Name = name;
            this.categories = new HashSet<ICategory>();
        }

        public string Name { get; }
        public IEnumerable<ICategory> Categories => this.categories as IReadOnlyCollection<ICategory>;
        public void AddCategory(ICategory category) => this.categories.Add(category);
        public void RemoveCategory(ICategory category)
        {
            this.categories.RemoveWhere(c => c.Name == category.Name);
            if (category.Parent != null)
            {
                this.categories.Add(category.Parent);
            }
        }
    }
}
