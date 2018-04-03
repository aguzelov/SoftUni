using NUnit.Framework;
using System;

namespace Database.Tests
{
    [TestFixture]
    public class DatabaseTests
    {
        private const int Capacity = 16;
        private Database database;

        [Test]
        public void TestFetchMethod()
        {
            //Arrange
            Person person = new Person(1, "Pencho");

            //Act
            this.database = new Database(person);

            //Assert
            Assert.AreEqual(person, this.database.Fetch()[0]);
        }

        [Test]
        public void InitDatabaseWithOneInteger()
        {
            //Arrange
            var expectedLength = 1;

            //Act
            this.database = new Database(new Person(1, "Pencho"));
            //Assert
            Assert.AreEqual(expectedLength, this.database.Fetch().Length);
        }

        [Test]
        public void InitDatabaseWithMaxCapacity()
        {
            //Arrange
            Person[] array = new Person[Capacity];
            for (int i = 0; i < Capacity; i++)
            {
                array[i] = new Person(i, "Pencho" + i);
            }

            //Act
            this.database = new Database(array);

            //Assert
            Assert.AreEqual(Capacity, this.database.Fetch().Length);
        }

        [Test]
        public void InitDatabaseWithMoreIntegersThanCapacity()
        {
            //Arrange
            Person[] array = new Person[17];
            for (int i = 0; i < 17; i++)
            {
                array[i] = new Person(i, "Pencho" + i);
            }

            //Act

            //Assert
            Assert.Throws<InvalidOperationException>(() => this.database = new Database(array));
        }

        [Test]
        public void AddOneElementInDatabase()
        {
            //Arrange
            Person element = new Person(1, "Pencho" + 1);
            int expected = 2;
            this.database = new Database(element);

            //Act
            this.database.Add(new Person(2, "Pencho" + 2));

            //Assert
            Assert.AreEqual(expected, this.database.Fetch().Length);
        }

        [Test]
        public void AddElementWithSameUsernameInDatabase()
        {
            //Arrange
            Person element = new Person(1, "Pencho");
            this.database = new Database(element);

            //Act
            Person newElementWithSameUsername = new Person(2, "Pencho");

            //Assert
            Assert.Throws<InvalidOperationException>(() => this.database.Add(newElementWithSameUsername));
        }

        [Test]
        public void AddElementWithSameIdInDatabase()
        {
            //Arrange
            Person element = new Person(1, "Pencho");
            this.database = new Database(element);

            //Act
            Person newElementWithSameUsername = new Person(1, "Pencho1");

            //Assert
            Assert.Throws<InvalidOperationException>(() => this.database.Add(newElementWithSameUsername));
        }

        [Test]
        public void AddToNextFreeCell()
        {
            //Arrange
            Person element = new Person(1, "Pencho");
            Person elementToAdd = new Person(2, "Pencho1"); ;
            this.database = new Database(element);

            //Act
            this.database.Add(elementToAdd);

            //Assert
            Assert.AreEqual(new Person[] { element, elementToAdd }, this.database.Fetch());
        }

        [Test]
        public void AddElementsEqualToCapacity()
        {
            //Arrange
            Person initElement = new Person(0, "Pencho");
            this.database = new Database(initElement);

            //Act

            for (int i = 1; i < Capacity; i++)
            {
                this.database.Add(new Person(i, "Pencho" + i));
            }

            //Assert
            Assert.AreEqual(16, this.database.Fetch().Length);
        }

        [Test]
        public void AddMoreThanCapacity()
        {
            //Arrange
            Person initElement = new Person(0, "Pencho");
            this.database = new Database(initElement);

            //Act

            for (int i = 1; i < Capacity; i++)
            {
                this.database.Add(new Person(i, "Pencho" + i));
            }
            //Assert
            Assert.Throws<InvalidOperationException>(() => this.database.Add(new Person(17, "Pencho" + 17)));
        }

        [Test]
        public void RemoveOneElementFromDatabaseWithMoreThanOne()
        {
            //Arrange
            Person first = new Person(1, "Pencho");
            Person second = new Person(2, "Pencho1"); ;
            this.database = new Database(first, second);

            //Act
            this.database.Remove();

            //Assert
            Assert.AreEqual(new Person[] { first }, this.database.Fetch());
        }

        [Test]
        public void RemoveOneElementFromDatabaseWitOneElement()
        {
            //Arrange
            Person first = new Person(1, "Pencho");
            this.database = new Database(first);

            //Act
            this.database.Remove();

            //Assert
            Assert.AreEqual(0, this.database.Fetch().Length);
        }

        [Test]
        public void RemoveOneElementFromEmptyDatabase()
        {
            //Arrange
            Person first = new Person(1, "Pencho");
            this.database = new Database(first);

            //Act
            this.database.Remove();

            //Assert
            Assert.Throws<InvalidOperationException>(() => this.database.Remove());
        }

        [Test]
        public void FindElementById()
        {
            //Arrange
            Person expected = new Person(1, "Pencho");
            this.database = new Database(expected);

            //Act
            Person result = this.database.FindById(1);

            //Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void FindElementByIdInDatabaseWithoutThatElement()
        {
            //Arrange
            Person expected = new Person(1, "Pencho");
            this.database = new Database(expected);

            //Act

            //Assert
            Assert.Throws<InvalidOperationException>(() => this.database.FindById(2));
        }

        [Test]
        public void FindElementByNegativeId()
        {
            //Arrange
            Person expected = new Person(1, "Pencho");
            this.database = new Database(expected);

            //Act

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => this.database.FindById(-1));
        }

        [Test]
        public void FindElementByUsername()
        {
            //Arrange
            Person expected = new Person(1, "Pencho");
            this.database = new Database(expected);

            //Act
            Person result = this.database.FindByUsername("Pencho");

            //Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void FindElementByUsernameInDatabaseWithoutThatElement()
        {
            //Arrange
            Person expected = new Person(1, "Pencho");
            this.database = new Database(expected);

            //Act

            //Assert
            Assert.Throws<InvalidOperationException>(() => this.database.FindByUsername("Gradimarin"));
        }

        [Test]
        public void FindElementByUsernameAsNullParameter()
        {
            //Arrange
            Person expected = new Person(1, "Pencho");
            this.database = new Database(expected);

            //Act

            //Assert
            Assert.Throws<ArgumentNullException>(() => this.database.FindByUsername(null));
        }

        [Test]
        public void FindElementByUsernameCaseSansitive()
        {
            //Arrange
            Person expected = new Person(1, "Pencho");
            this.database = new Database(expected);

            //Act

            //Assert
            Assert.Throws<InvalidOperationException>(() => this.database.FindByUsername("pencho"));
        }
    }
}