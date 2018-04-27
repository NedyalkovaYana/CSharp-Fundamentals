using System;
using NUnit.Framework;
using _01.DataBaseT;
using _02.ExtendedDatabase;

namespace ExtendetDatabase.Tests
{
    [TestFixture]
    public class Tests
    {
        private Database db;

        [SetUp]
        public void InitializeData()
        {
            this.db = new Database();
        }

        [Test]
        public void TestValidConstructor()
        {
            var person1 = new People(1, "Ivan");
            var person2 = new People(2, "Ani");

            var collection = new IPeople[] {person1, person2};
            db = new Database(collection);

            Assert.AreEqual(2, this.db.Count);
        }

        [Test]

        public void TestAddMethodInvalid()
        {
            var person1 = new People(1, "Chocko");
            var person2 = new People(1, "Chocko");

            var collection = new IPeople[] {person1, person2};

           // this.db = new Database(collection);

            Assert.That(() => new Database(collection), Throws.InvalidOperationException);
        }

        [Test]
        public void TestRemoveMethod()
        {
            var person1 = new People(1, "Test1");
            var person2 = new People(2, "Test2");
            var person3 = new People(3, "Test3");

            var collection = new IPeople[] { person1, person2, person3};

            this.db = new Database(collection);
            this.db.Remove(person1);

            Assert.AreEqual(2, this.db.Count);
        }

        [Test]
        public void TestFindByUsername_WhitNullReference()
        {
            var person1 = new People(1, "Test1");
            var person2 = new People(2, "Test2");

            var collection = new IPeople[] {person1, person2};

            this.db = new Database(collection);
        
            Assert.That(() => db.FindByUsername(null), Throws.ArgumentNullException);
        }

        [Test]
        public void TestFindByUsername_WhitInvalidPersonName()
        {
            var person1 = new People(1, "Test1");
            var person2 = new People(2, "Test2");

            var collection = new IPeople[] { person1, person2 };

            this.db = new Database(collection);

            Assert.That(() => db.FindByUsername("Test3"), Throws.InvalidOperationException);
        }

        [Test]
        public void TestFindByUsername_WithValidData()
        {
            var person1 = new People(1, "Test1");
            var person2 = new People(2, "Test2");

            var collection = new IPeople[] { person1, person2 };

            this.db = new Database(collection);

            Assert.AreEqual(person2, db.FindByUsername("Test2"));
        }

        [Test]
        public void FindById_WhithNegativeID()
        {
            Assert.Throws<ArgumentOutOfRangeException>
                (() => this.db.FindById(-1));
        }

        [Test]
        public void FindById_WhithNonExistingID()
        {
            Assert.Throws<InvalidOperationException>
                (() => this.db.FindById(1));
        }

        [Test]
        [TestCase(1)]
        public void FindById_WhithCorrectData(long id)
        {
            var person1 = new People(1, "Test1");
            var person2 = new People(2, "Test2");

            var collection = new IPeople[] { person1, person2 };

            this.db = new Database(collection);
            Assert.AreEqual(person1, db.FindById(id));
        }
    }
}
