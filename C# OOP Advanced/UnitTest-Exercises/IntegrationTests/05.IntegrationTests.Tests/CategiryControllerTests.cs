using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using IntegrationTests.Interfaces;
using IntegrationTests.Models;
using NUnit.Framework;

namespace IntegrationTests.Tests
{
    [TestFixture]
    public class CategiryControllerTests
    {
        private const string CategoryNameCons = "Test";
        private const string UserNameCons = "User";
        private CategoryController categoryController;
        private HashSet<ICategory> categories;

        [SetUp]
        public void TestInit()
        {
            this.categoryController = new CategoryController();

            this.categories = (HashSet<ICategory>) this.categoryController.GetType()
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(n => n.Name == "categories")
                .GetValue(this.categoryController);
        }

        [Test]
        public void AddCategory_ShoudSaveCategory()
        {
            var categoryName = "Category Name";
            this.categoryController.AddCategory(categoryName);

            Assert.AreEqual(1, this.categories.Count);
        }

        [Test]
        [TestCase(5)]
        [TestCase(50)]
        public void AddMoreThanOneCategoryShouldSaveAllOfThem(int numberOfCatecories)
        {
            var categoryName = "Test";

            for (int i = 0; i < numberOfCatecories; i++)
            {
                this.categoryController.AddCategory($"{categoryName} - {i}");
            }

            Assert.AreEqual(numberOfCatecories, categories.Count);
        }

        [Test]
        public void CannotAddCategoryWithoutName()
        {
            Assert.Throws<ArgumentException>(() => this.categoryController.AddCategory(""));
        }

        [Test]
        public void AddChild_ShouldAssignAChildCategoryToTheParent()
        {
            var parentName = "Parent";
            this.categoryController.AddCategory(parentName);
            var parentCategory = this.categories
                        .FirstOrDefault(f => f.Name == parentName);

            this.categoryController.AddChild(parentCategory, "ChildName");

            Assert.AreEqual(1, parentCategory.ChildCategories.Count);
        }

        [Test]
        public void AddUserShouldAssignUserToASpecificCategory()
        {
            this.categoryController.AddCategory(CategoryNameCons);
            var addedCategory = this.categories.First(c => c.Name == CategoryNameCons);

            this.categoryController.AddUser(addedCategory, new User(UserNameCons));

            Assert.AreEqual(1, addedCategory.Users.Count);
        }

        [Test]
        public void AddUserShouldAssignTheCategoryToItsUserListOfCategories()
        {
            this.categoryController.AddCategory(CategoryNameCons);
            var user = new User(UserNameCons);

            this.categoryController.AddUser(this.categories.First(), user);
        }

        [Test]
        public void RemoveCategoryByNameShouldDeleteIt()
        {
            var numberOfCategories = 10;

            for (int i = 0; i < numberOfCategories; i++)
            {
                this.categoryController.AddCategory(CategoryNameCons + " " + $"{i}");
            }

            this.categoryController.RemoveCategory(CategoryNameCons + " " + 0);

            Assert.AreEqual(numberOfCategories - 1, this.categories.Count);
        }

        [Test]
        [TestCase(2)]
        [TestCase(10)]
        [TestCase(20)]
        public void RemoveCategoryWithCollectionOFNameShoudDeleteThem(int numberOfDeletion)
        {
            var numberOfCategories = numberOfDeletion + 5;

            for (int i = 0; i < numberOfCategories; i++)
            {
                this.categoryController.AddCategory(CategoryNameCons + " " + $"{i}");
            }

            var deletionName = new string[numberOfDeletion];

            for (int i = 0; i < deletionName.Length; i++)
            {
                deletionName[i] = CategoryNameCons + " " + $"{i}";
            }

            this.categoryController.RemoveCategory(deletionName);

            Assert.AreEqual(numberOfCategories - deletionName.Length, this.categories.Count);
        }

        [Test]
        public void RemoveCategoryShouldMoveChildCategoriesToItsParentOne()
        {
            var firstCategoryName = "First";
            var secondCategoryName = "First's child";
            var thirdCategoryName = "Second's child & First's sub-child";

            this.categoryController.AddCategory(firstCategoryName);
            var biggestParrent = this.categories.First();
            this.categoryController.AddChild(biggestParrent, secondCategoryName);
            this.categoryController.AddChild(biggestParrent.ChildCategories.First(), thirdCategoryName);

            this.categoryController.RemoveCategory(secondCategoryName);

            Assert.AreEqual(1, this.categories.First().ChildCategories.Count);
        }

    }
}
