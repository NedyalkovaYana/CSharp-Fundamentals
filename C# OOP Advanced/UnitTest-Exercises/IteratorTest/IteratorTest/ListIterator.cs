using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IteratorTest
{
    public class ListIterator : IListIterator
    {
        private const string ExceptionMessage = "Invalid Operation!";
        private List<string> collection;
        private int index;

        public ListIterator(IEnumerable<string> inputCollection)
        {
            this.NullValidation(inputCollection);
            this.collection = new List<string>(inputCollection);
            this.index = 0;
        }

        private void NullValidation(IEnumerable<string> inputCollection)
        {
            if (inputCollection == null)
            {
                throw new ArgumentNullException();
            }
        }

        public bool Move()
        {
            if (index + 1 < collection.Count)
            {
                index++;
                return true;
            }

            return false;
        }

        public bool HasNext()
        {
            if (index + 1 < collection.Count)
            {
                return true;
            }

            return false;
        }

        public string Print()
        {
            if (collection.Count <= 0)
            {
                throw new ArgumentException(ExceptionMessage);
            }

            return collection[index];
        }
    }
}
