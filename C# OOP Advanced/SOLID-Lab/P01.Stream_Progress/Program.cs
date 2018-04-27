using System;

namespace P01.Stream_Progress
{
    public class Program
    {
        static void Main()
        {   
            var progresInfo = new StreamProgressInfo(new Music("Pep", "Pop", 5, 4));
            Console.WriteLine(progresInfo.CalculateCurrentPercent());
            var progressInfo2 = new StreamProgressInfo(new File("Gog", 12, 3));
            Console.WriteLine(progressInfo2.CalculateCurrentPercent());
        }
    }
}
