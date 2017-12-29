namespace _04.Basic_Queue_Operations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class BasicQueueOperations
    {
        static void Main()
        {
            var inputCommands = 
                Console.ReadLine()
                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var myQueue = new Queue<int>();

            var elementToEnqueue = inputCommands[0];
            var elementToDequeue = inputCommands[1];

            if (inputCommands.Count > 1 && elementToEnqueue > elementToDequeue)
            {
                Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList()
                    .ForEach(n => myQueue.Enqueue(n));
            }

            if (inputCommands.Count > 2)
            {
                Console.WriteLine(myQueue.Count == 0 ? "0" : myQueue.Contains(inputCommands[2]) ? "true" : $"{myQueue.Min()}");
            }

        }
    }
}
