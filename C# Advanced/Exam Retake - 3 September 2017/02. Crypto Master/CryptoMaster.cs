using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;


namespace _02.Crypto_Master
{
    class CryptoMaster
    {
        static void Main()
        {
            var inputNumbers = Console.ReadLine()
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToList();

            var seqLength = inputNumbers.Count;
            var maxLength = 0L;

            for (int step = 1; step < seqLength; step++)
            {
                for (int i = 0; i < seqLength; i++)
                {
                    var localMax = 1;
                    var currentElementIndex = i;
                    var nextElementIndex = (currentElementIndex + step) % inputNumbers.Count;

                    while (inputNumbers[nextElementIndex] > inputNumbers[currentElementIndex])
                    {
                        localMax++;

                        currentElementIndex = nextElementIndex;
                        nextElementIndex = (currentElementIndex + step) % inputNumbers.Count;
                    }
                    if (maxLength < localMax)
                    {
                        maxLength = localMax;
                    }
                }
            }
            Console.WriteLine(maxLength);
        }
    }
}
