using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInversion.Strategies
{
    class MultipleStrategy : IStrategy
    {
        public int Calculate(int first, int second)
        {
            return first * second;
        }
    }
}
