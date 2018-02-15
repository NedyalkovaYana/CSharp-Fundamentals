using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreverstDirectory
{
    class Program
    {
        static void Main(string[] args)
        {
            TraverseDirectory("Me");
        }

        public static void TraverseDirectory(string directory)
        {
            Console.WriteLine($"---{directory}---");
            Console.WriteLine("*** *** ***");

            string[] allFiles = Directory.GetFiles(directory);

            foreach (var file in allFiles)
            {
                Console.WriteLine(file);
            }

            string[] allDirs = Directory.GetDirectories(directory);

            foreach (var dir in allDirs)
            {
                TraverseDirectory(dir);
            }

        }
    }
}
