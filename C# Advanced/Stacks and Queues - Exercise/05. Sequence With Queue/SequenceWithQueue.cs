namespace _05.Sequence_With_Queue
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class SequenceWithQueue
    {
        static void Main()
        {
            var n = long.Parse(Console.ReadLine());

            var sequence = new Queue<long>();
            sequence.Enqueue(n);
            //var s = n;  //100/100

            //for (int i = 0, skipCount = 0; i < 49; i++)
            //{
            //    switch (i % 3)
            //    {
            //        case 0:
            //            s =  sequence
            //                .ToArray()
            //                .Skip(skipCount)
            //                .Take(1)
            //                .ToArray()[0];
            //            sequence.Enqueue(s + 1);
            //            skipCount++;
            //            break;
            //        case 1:
            //            sequence.Enqueue(2 * s + 1);
            //            break;
            //        case 2:
            //            sequence.Enqueue(s + 2);
            //            break;
            //    }
            //}

            //Console.WriteLine(string.Join(" ", sequence));

            var resultList = new List<long>();
            resultList.Add(n);
            while (resultList.Count < 50)
            {
                var currentElement = sequence.Dequeue();
                var firstNumber = currentElement + 1;
                var secondNumber = 2 * currentElement + 1;
                var thirdNumber = currentElement + 2;

                sequence.Enqueue(firstNumber);
                sequence.Enqueue(secondNumber);
                sequence.Enqueue(thirdNumber);

                resultList.Add(firstNumber);
                resultList.Add(secondNumber);
                resultList.Add(thirdNumber);
            }

            for (int i = 0; i < 50; i++)
            {
                Console.Write(resultList[i] + " ");
            }
        }
    }
}
