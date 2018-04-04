using System;
using System.Collections.Generic;
using System.Linq;

namespace Iterator
{
    public class ListIterator
    {
        private List<string> collection;
        private int index;

        public ListIterator(params string[] collection)
        {
            this.AddCollection(collection);
            this.index = 0;
        }

        internal object Skip(int v)
        {
            throw new NotImplementedException();
        }

        private void AddCollection(ICollection<string> collection)
        {
            if (collection == null || collection.Any(e => e == null))
            {
                throw new ArgumentNullException();
            }

            this.collection = new List<string>(collection);
        }

        public bool Move()
        {
            if (this.HasNext())
            {
                this.index++;
                return true;
            }

            return false;
        }

        public bool HasNext()
        {
            if (this.index >= this.collection.Count - 1)
            {
                return false;
            }

            return true;
        }

        public string Print()
        {
            if (this.collection.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            string element = this.collection[this.index];
            return element;
        }
    }
}