namespace _03.Maximum_Element
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    class Program
    {
        static void Main()
        {
            var maxElementList = new List<int>();
            var myStack = new Stack<int>();
            var n = int.Parse(Console.ReadLine());
            var maxElement = 0;
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split();
                var command = input[0];

                if (command == "1")
                {
                    
                    var elementToPush = int.Parse(input[1]);
                    if (elementToPush > maxElement)
                    {
                        maxElement = elementToPush;
                        maxElementList.Add(maxElement);
                    }
                    myStack.Push(elementToPush);
                }
                else if (command == "2")
                {                   
                    var elementToDelete = myStack.Pop();
                    if (elementToDelete ==  maxElement)
                    {
                        maxElementList.Remove(maxElement);
                        if (maxElementList.Count == 0)
                        {
                            maxElement = 0;
                        }
                        else
                        {
                            maxElement = maxElementList.Max();
                        }
                    }
                }
                else
                {
                    Console.WriteLine(maxElement);
                }
            }
        }
    }
}
