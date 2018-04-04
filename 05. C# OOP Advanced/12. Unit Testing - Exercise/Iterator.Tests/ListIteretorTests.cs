using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Iterator.Tests
{
    [TestFixture]
    public class ListIteretorTests
    {
        private ListIterator list;

        [Test]
        public void InitListWithNull()
        {
            //Arrange
            string[] args = new string[] { "1", null };

            //Act

            //Assert
            Assert.Throws<ArgumentNullException>(() => this.list = new ListIterator(args));
        }

        [Test]
        public void InitEmptyList()
        {
            //Arrange
            this.list = new ListIterator();
            int expectedValue = 0;

            //Act
            FieldInfo[] fieldsInfo = this.list.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

            int indexValue = (int)fieldsInfo.First(i => i.Name == "index").GetValue(this.list);

            var collection = (List<string>)fieldsInfo.First(c => c.Name == "collection").GetValue(this.list);

            //Assert
            Assert.AreEqual(expectedValue, indexValue);
            Assert.AreEqual(expectedValue, collection.Count);
        }

        [Test]
        public void InitList()
        {
            //Arrange
            this.list = new ListIterator("1", "2", "3");
            string[] expectedValue = new string[] { "1", "2", "3" };

            //Act
            FieldInfo[] fieldsInfo = this.list.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

            var collection = (List<string>)fieldsInfo.First(c => c.Name == "collection").GetValue(this.list);

            //Assert
            Assert.AreEqual(expectedValue, collection);
        }

        [Test]
        public void TestHasNext()
        {
            //Arrange
            this.list = new ListIterator("1", "2", "3");
            bool expected = true;

            //Act
            bool actual = this.list.HasNext();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestHasNextWithNoElementsInList()
        {
            //Arrange
            this.list = new ListIterator();
            bool expected = false;

            //Act
            bool actual = this.list.HasNext();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestHasNextWithNoNextElement()
        {
            //Arrange
            this.list = new ListIterator("1");
            bool expected = false;

            //Act
            bool actual = this.list.HasNext();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestMoveWithElementsInList()
        {
            //Arrange
            this.list = new ListIterator("1", "2", "3");
            bool expectedMoveResult = true;
            int expectedIndexValue = 1;

            //Act
            bool actualMoveResult = this.list.Move();

            FieldInfo[] fieldsInfo = this.list.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

            int actualIndexValue = (int)fieldsInfo.First(i => i.Name == "index").GetValue(this.list);

            //Assert
            Assert.AreEqual(expectedMoveResult, actualMoveResult);
            Assert.AreEqual(expectedIndexValue, actualIndexValue);
        }

        [Test]
        public void TestMoveWithNoElementsInList()
        {
            //Arrange
            this.list = new ListIterator();
            bool expectedMoveResult = false;
            int expectedIndexValue = 0;

            //Act
            bool actualMoveResult = this.list.Move();

            FieldInfo[] fieldsInfo = this.list.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

            int actualIndexValue = (int)fieldsInfo.First(i => i.Name == "index").GetValue(this.list);

            //Assert
            Assert.AreEqual(expectedMoveResult, actualMoveResult);
            Assert.AreEqual(expectedIndexValue, actualIndexValue);
        }

        [Test]
        public void TestMoveThroughWholeList()
        {
            //Arrange
            this.list = new ListIterator("1", "2", "3");
            bool expectedMoveResult = false;
            int expectedIndexValue = 2;

            //Act
            bool actualMoveResult = true;
            for (int i = 0; i < 4; i++)
            {
                actualMoveResult = this.list.Move();
            }

            FieldInfo[] fieldsInfo = this.list.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

            int actualIndexValue = (int)fieldsInfo.First(i => i.Name == "index").GetValue(this.list);

            //Assert
            Assert.AreEqual(expectedMoveResult, actualMoveResult);
            Assert.AreEqual(expectedIndexValue, actualIndexValue);
        }

        [Test]
        public void TestPrintWithElementsInList()
        {
            //Arrange
            string[] array = new string[] { "1", "2", "3" };
            this.list = new ListIterator(array);
            int index = 0;

            //Act

            //Assert

            while (this.list.HasNext())
            {
                string actualResult = this.list.Print();
                this.list.Move();

                Assert.AreEqual(array[index], actualResult);
                index++;
            }
        }

        [Test]
        public void TestPrintWithEmptyInList()
        {
            //Arrange
            this.list = new ListIterator();

            //Act

            //Assert
            Assert.Throws<InvalidOperationException>(() => this.list.Print());
        }
    }
}