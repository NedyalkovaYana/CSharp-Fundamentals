using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using IteratorTest;
using NUnit.Framework;

namespace ITeratorTest.Test
{
    [TestFixture]
    public class IteratorTests
    {
        private IListIterator list;
        private List<string> values = new List<string>();
        [SetUp]
        public void InitializeData()
        {
            values = new List<string> {"1", "2"/*, "3", "4"*/};

            this.list = new ListIterator(values);
        }

        [Test]
        public void TestConstructor_WithValidParams()
        {
            var fieldInfo = typeof(ListIterator)
                .GetFields(BindingFlags.Instance | 
                           BindingFlags.NonPublic | 
                           BindingFlags.Public)
                .First(f => f.FieldType == typeof(List<string>));

            var fieldValues = (List<string>) fieldInfo.GetValue(list);

            Assert.That(fieldValues, Is.EquivalentTo(values));
        }

        [Test]
        public void TestConstructor_WithNull_ExpectedException()
        {
            Assert.Throws<ArgumentNullException>
                (() => new ListIterator(null));
        }

        [Test]
        public void TestMoveMethod_WithExistingNextIndex()
        {
            Assert.AreEqual(true, this.list.Move());
        }

        [Test]
        public void TestMoveMethod_WithNonExistingNextIndex()
        {
            this.list.Move();
            this.list.Move();

            Assert.AreEqual(false, this.list.Move());
        }

        [Test]
        public void TestMoveMethod_MoveIndexToNextElement()
        {
            this.list.Move();

            var indexValue = typeof(ListIterator)
                .GetFields(BindingFlags.NonPublic |
                           BindingFlags.Instance |
                           BindingFlags.Public)
                .First(i => i.FieldType == typeof(int))
                .GetValue(this.list);

            Assert.AreEqual(1, indexValue);
        }

        [Test]
        public void TestHasNextMethod_WithExistingNextIndex()
        {
            Assert.AreEqual(true, this.list.HasNext());
        }

        [Test]
        public void TestHasNextMethod_WithNonExistingNextIndex()
        {
            this.list.Move();
            this.list.Move();

            Assert.AreEqual(false, this.list.HasNext());
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        public void TestPrintMethod_WithValidParams(int elementToReturn)
        {
            for (int i = 0; i < elementToReturn; i++)
            {
                this.list.Move();
            }

            Assert.AreEqual(this.values[elementToReturn], this.list.Print());
        }

        [Test]
        public void TestPrintMethod_WithEmptyList_ExpextedException()
        {
            this.list = new ListIterator(new List<string>());

            Assert.Throws<ArgumentException>(() => this.list.Print());
        }
    }
}
