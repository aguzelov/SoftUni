using BashSoft.Contracts;
using BashSoft.DataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

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
            this.names = new SimpleSortedList<string>();

            Assert.AreEqual(this.names.Capacity, 16);
            Assert.AreEqual(this.names.Size, 0);
        }

        [TestMethod]
        public void TestCtorWithInitialCapacity()
        {
            this.names = new SimpleSortedList<string>(20);

            Assert.AreEqual(this.names.Capacity, 20);
            Assert.AreEqual(this.names.Size, 0);
        }

        [TestMethod]
        public void TestCtorWithAllParams()
        {
            this.names = new SimpleSortedList<string>(StringComparer.OrdinalIgnoreCase, 30);

            Assert.AreEqual(this.names.Capacity, 30);
            Assert.AreEqual(this.names.Size, 0);
        }

        [TestMethod]
        public void TestCtorWithInitialComparer()
        {
            this.names = new SimpleSortedList<string>(StringComparer.OrdinalIgnoreCase);

            Assert.AreEqual(this.names.Capacity, 16);
            Assert.AreEqual(this.names.Size, 0);
        }

        [TestMethod]
        public void TestAddIncreasesSize()
        {
            this.names.Add("Nasko");
            Assert.AreEqual(1, this.names.Size);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestAddNullThrowException()
        {
            this.names.Add(null);
        }

        [TestMethod]
        public void TestAddUnsortedDataIsHeldSorted()
        {
            List<string> addedNames = new List<string>()
            {
                "Rosen", "Georgi", "Balkan"
            };

            foreach (var addedName in addedNames)
            {
                this.names.Add(addedName);
            }

            int index = addedNames.Count - 1;
            foreach (var name in this.names)
            {
                Assert.AreEqual(addedNames[index], name);
                index--;
            }
        }

        [TestMethod]
        public void TestAddingMoreThanInitialCapacity()
        {
            for (int i = 0; i < 17; i++)
            {
                this.names.Add("Element: " + i);
            }

            Assert.AreEqual(17, this.names.Size);
            Assert.AreNotEqual(16, this.names.Capacity);
        }

        [TestMethod]
        public void TestAddingAllFromCollectionIncreasesSize()
        {
            List<string> twoElements = new List<string>()
            {
                "First", "Second"
            };

            this.names.AddAll(twoElements);

            Assert.AreEqual(2, this.names.Size);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestAddingAllFromNullThrowsException()
        {
            this.names.AddAll(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestAddingAllNullElementFromNullThrowsException()
        {
            List<string> elements = new List<string>()
            {
                "first", null, "second"
            };

            this.names.AddAll(elements);
        }

        [TestMethod]
        public void TestAddAllKeepsSorted()
        {
            List<string> addedNames = new List<string>()
            {
                "Rosen", "Georgi", "Balkan"
            };

            this.names.AddAll(addedNames);

            int index = addedNames.Count - 1;
            foreach (var name in this.names)
            {
                Assert.AreEqual(addedNames[index], name);
                index--;
            }
        }

        [TestMethod]
        public void TestRemoveValidElementDecreasesSize()
        {
            string element = "Element";

            this.names.Add(element);
            this.names.Remove(element);

            Assert.AreEqual(0, this.names.Size);
        }

        [TestMethod]
        public void TestRemoveValidElementRemovesSelectedOne()
        {
            this.names.Add("Ivan");
            this.names.Add("Pancho");

            this.names.Remove("Ivan");

            bool hasFoundIvan = false;
            foreach (var name in this.names)
            {
                if (name == "Ivan") ;
            }
            Assert.IsFalse(hasFoundIvan);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestRemovingNullThrowsException()
        {
            this.names.Remove(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestJoinWithNull()
        {
            this.names.JoinWith(null);
        }

        [TestMethod]
        public void TestJoinWorksFine()
        {
            string joiner = ", ";

            this.names.Add("First");
            this.names.Add("Second");

            string result = this.names.JoinWith(joiner);

            Assert.AreEqual("First, Second", result);
        }
    }
}