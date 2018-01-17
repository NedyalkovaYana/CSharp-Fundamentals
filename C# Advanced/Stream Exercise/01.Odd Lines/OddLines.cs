namespace _01.Odd_Lines
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    class OddLines
    {
        static void Main()
        {
            Console.Write("Choose a file path:");
            var filePath = Console.ReadLine();
            var count = 0;
            using (var reader = new StreamReader(filePath))
            {
                using (var writer = new StreamWriter("../../result.txt"))
                {
                    var readLine = string.Empty;
                    while (readLine != null)
                    {
                        readLine = reader.ReadLine();
                        if (count % 2 != 0)
                        {
                            writer.WriteLine(readLine);
                        }
                        count++;
                    }
                }

            }
        }
    }
}
