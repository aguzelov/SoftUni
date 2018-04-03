using System;
using System.Linq;

namespace Database
{
    public class Database
    {
        private const int InitCapacity = 16;
        private Person[] elements;
        private int currentElementIndex;

        private Database()
        {
            this.elements = new Person[InitCapacity];
            this.currentElementIndex = 0;
        }

        public Database(params Person[] elements)
            : this()
        {
            this.AddRange(elements);
        }

        public void Add(Person person)
        {
            if (this.currentElementIndex == InitCapacity)
            {
                throw new InvalidOperationException("CapacityOverflow");
            }

            if (this.elements.Any(p => p != null && p.Username == person.Username || p != null && p.Id == person.Id))
            {
                throw new InvalidOperationException("Already have that person in database!");
            }

            this.elements[this.currentElementIndex] = person;
            this.currentElementIndex++;
        }

        private void AddRange(Person[] range)
        {
            if (range.Length > 16)
            {
                throw new InvalidOperationException("Count of added element is more than capacity(16)");
            }

            foreach (var element in range)
            {
                this.Add(element);
            }
        }

        public void Remove()
        {
            this.currentElementIndex--;
            if (this.currentElementIndex < 0)
            {
                this.currentElementIndex = 0;
                throw new InvalidOperationException("Empty database!");
            }
            this.elements[this.currentElementIndex] = default(Person);
        }

        public Person FindById(long id)
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException("Negative Id!");
            }

            if (!this.elements.Any(p => p != null && p.Id == id))
            {
                throw new InvalidOperationException("No person with this id!");
            }

            Person person = this.elements.First(p => p.Id == id);

            return person;
        }

        public Person FindByUsername(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentNullException("Username parameter is null!");
            }

            if (!this.elements.Any(p => p != null && p.Username == username))
            {
                throw new InvalidOperationException("No person with this username!");
            }

            Person person = this.elements.First(p => p.Username == username);

            return person;
        }

        public Person[] Fetch()
        {
            Person[] subarray = this.elements.Skip(0).Take(this.currentElementIndex).ToArray();

            return subarray;
        }
    }
}