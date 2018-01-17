namespace _02.Line_Number
{
    using System;
    using System.IO;
    public class LineNumber
    {
        public static void Main()
        {
            Console.Write("Choose a file path:");
            var filePath = Console.ReadLine();
            
            using (var reader = new StreamReader(filePath))
            {
                using (var writer = new StreamWriter("../../result.txt"))
                {
                    var readLine = string.Empty;
                    int count = 1;
                    while ((readLine = reader.ReadLine()) != null)
                    {                       
                        writer.WriteLine($"{count} {readLine}");
                       count++;
                    }
                }
            }
            
        }
    }
}
