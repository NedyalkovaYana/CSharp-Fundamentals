using System;
using CustomLinkedList;
using NUnit.Framework;

namespace _08.CustomLinkedList.Tests
{
    [TestFixture]
    public class DinamicListTests
    {
        private DynamicList<int> sut;
        private const int InCorrectedIndex = -1;

        [SetUp]
        public void SetList()
        {
            this.sut = new DynamicList<int>();
        }

        [Test]
        public void CannotCallElementWithNegativeIndex()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var test = this.sut[InCorrectedIndex];
            });
        }

        [Test]
        public void CannotCallElementWitIndexAboveTheRange()
        {
            var incorrectIndex = 1;
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var test = this.sut[incorrectIndex];
            });
        }

        [Test]
        public void AddShouldIncreaseCollectionCount()
        {
            this.sut.Add(100);

            Assert.AreEqual(1, this.sut.Count);
        }

        [Test]
        [TestCase(1, 0)]
        [TestCase(5, 0)]
        [TestCase(10, 0)]
        [TestCase(15, 0)]
        public void AddShouldSaveTheElementInTheCollection(int numberOfAdditions, int indexToCheck)
        {
            // Act
            this.sut.Add(numberOfAdditions);

            // Assert
            Assert.AreEqual(numberOfAdditions, this.sut[indexToCheck], "Element is not the same as the one added");
        }


        [Test]
        [TestCase(-1)]
        [TestCase(1)]
        [TestCase(-5)]
        [TestCase(5)]
        public void RemoveAtIndexOusideTheBoundariesOfTheCollectionIsImpossible(int indexToRemove)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => this.sut.RemoveAt(indexToRemove));

        }
    }
}
