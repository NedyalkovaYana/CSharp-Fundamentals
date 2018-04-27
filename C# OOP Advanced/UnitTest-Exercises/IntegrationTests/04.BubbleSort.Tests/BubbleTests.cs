using System;
using NUnit.Framework;

namespace _04.BubbleSort.Tests
{
    [TestFixture]
    public class BubbleTests
    {
        private Bubble bubble;

        [SetUp]
        public void InitializeBubbleClass()
        {
            this.bubble = new Bubble();
        }

        [Test]
        [TestCase(9, 2, 3, 4, 5, 6, 7, 8, 1, 10)]
        [TestCase(9, 8, 7, 6, 5, 10, 4, 3, 2, 1)]
        public void BubbleCanSortNumbers(params int[] collectionToSort)
        {
            var sortedCollection = new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

            bubble.Sort(collectionToSort);

            Assert.AreEqual(sortedCollection, collectionToSort);
        }


    }
}
