namespace Classwork
{
    using System;
    using System.IO;
    class StreamReader_StreamWriter
    {
        private static void Main()
        {
            using (var reader = new StreamReader("text.txt"))
            {
                var currentLine = reader.ReadLine();
                Console.WriteLine(currentLine);

                while (string.IsNullOrEmpty(currentLine))
                {
                    // do work on the line

                    currentLine = reader.ReadLine();
                }
            }

            //СТранични операции върху файловете:
            Path.GetDirectoryName("d:/test/pesho/gosho.txt");
            Path.GetFileNameWithoutExtension("numbers.txt");


        }
    }
}
