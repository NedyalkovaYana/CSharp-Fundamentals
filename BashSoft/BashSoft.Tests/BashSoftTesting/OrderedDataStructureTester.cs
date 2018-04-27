using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using BashSoft.Contracts;
using BashSoft.DataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BashSoftTesting
{
    [TestClass]
    public class OrderedDataStructureTester
    {
        private ISimpleOrderedBag<string> names;

        [TestInitialize]
        public void SetUp()
        {
            this.names = new SimpleSortedList<string>();
        }

        [TestMethod]
        public void TestEmptyCtor()
        {
            // Assert
            Assert.AreEqual(16, this.names.Capacity, "Initial capacity have to be 16");
            Assert.AreEqual(0, this.names.Size, "Initial size have to be 0");
        }

        [TestMethod]
        public void TestCtorWithInitialCapacity()
        {
            // Arrange
            this.names = new SimpleSortedList<string>(20);

            // Assert
            Assert.AreEqual(20, this.names.Capacity, "Capacity must be equal to the provided one");
            Assert.AreEqual(0, this.names.Size, "Initial size have to be 0");
        }

        [TestMethod]
        public void TestCtorWithAllParams()
        {
            // Arrange
            this.names = new SimpleSortedList<string>(30, StringComparer.OrdinalIgnoreCase);

            // Assert
            Assert.AreEqual(30, this.names.Capacity, "Capacity must be equal to the provided one");
            Assert.AreEqual(0, this.names.Size, "Initial size have to be 0");
        }

        [TestMethod]
        public void TestCtorWithInitialComparer()
        {
            // Arrange
            this.names = new SimpleSortedList<string>(StringComparer.OrdinalIgnoreCase);

            // Assert
            Assert.AreEqual(16, this.names.Capacity, "Initial capacity have to be 16");
            Assert.AreEqual(0, this.names.Size, "Initial size have to be 0");
        }

        [TestMethod]
        public void AddIncreasesSize()
        {
            //Act
            this.names.Add("Nasko");

            //Assert
            Assert.AreEqual(1, this.names.Size, "Add didn't change the size");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddNullThrowsException()
        {
            //Act
            this.names.Add(null);
        }

        [TestMethod]
        public void AddUnsortedDataIsHeldSorted()
        {
            // Arrange
            List<string> collection = new List<string>()
            {
                "Rosen",
                "Georgi",
                "Balkan"
            };

            // Act
            this.names.AddAll(collection);

            //Assert
            Assert.AreEqual("Balkan", this.names[0], "Elements are not sorted");
            Assert.AreEqual("Georgi", this.names[1], "Elements are not sorted");
            Assert.AreEqual("Rosen", this.names[2], "Elements are not sorted");
        }

        [TestMethod]
        public void AddingMoreThanInitialCapacity()
        {
            // Act
            for (int i = 0; i < 17; i++)
            {
                this.names.Add($"Name {i}");
            }

            //Assert
            Assert.AreEqual(17, names.Size);
            Assert.AreEqual(32, names.Capacity);
        }

        [TestMethod]
        public void AddingAllFromCollectionIncreasesSize()
        {
            //Arrange
            var list = new List<string>{"Test1", "Test2"};

            //Act
            names.AddAll(list);

            //Assert
            Assert.AreEqual(2, names.Size);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingAllFromNullThrowsException()
        {
            //Act
            names.AddAll(null);

            //Assert
            ArgumentNullException ex = 
                Assert.ThrowsException<ArgumentNullException>(() 
                => names.AddAll(null));

            Assert.AreEqual(null, ex.Message);
        }

        [TestMethod]
        public void AddAllKeepsSorted()
        {
            // Arrange
            List<string> collection = new List<string>()
            {
                "Rosen",
                "Blagoi",
                "Georgi",
                "Balkan",
                "Atanas"
            };

            // Act
            this.names.AddAll(collection);

            //Assert
            Assert.AreEqual("Atanas", this.names[0], "Elements are not sorted");
            Assert.AreEqual("Balkan", this.names[1], "Elements are not sorted");
            Assert.AreEqual("Blagoi", this.names[2], "Elements are not sorted");
            Assert.AreEqual("Georgi", this.names[3], "Elements are not sorted");
            Assert.AreEqual("Rosen", this.names[4], "Elements are not sorted");
        }

        [TestMethod]
        public void RemoveValidElementDecreasesSize()
        {
            //Act
            names.Add("element");
            names.Remove("element");

            //Assert
            Assert.AreEqual(0, names.Size);
        }

        [TestMethod]
        public void RemoveValidElementRemovesSelectedOne()
        {
            //Arrange
            names.Add("nasko");
            names.Add("ivan");

            //Act
            names.Remove("nasko");

            //Accert
            Assert.AreEqual("ivan", this.names[0]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RemovingNullThrowsException()
        {
            //Act
            names.Remove(null);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void JoinWithNull()
        {
            //Arrange
            this.names.AddAll(new string[] { "1", "2", "3" });

            //Act
            names.JoinWith(null);
        }

        [TestMethod]
        public void JoinWorksFine()
        {
            // Arrange
            this.names.AddAll(new string[] { "1", "2", "3" });

            // Assert
            Assert.AreEqual("1, 2, 3", this.names.JoinWith(", "));
        }
    }
}
