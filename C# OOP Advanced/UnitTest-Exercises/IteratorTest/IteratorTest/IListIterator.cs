using System;
using System.Collections.Generic;
using System.Text;

namespace IteratorTest
{
    public interface IListIterator
    {
        bool Move();
        bool HasNext();
        string Print();
    }
}
