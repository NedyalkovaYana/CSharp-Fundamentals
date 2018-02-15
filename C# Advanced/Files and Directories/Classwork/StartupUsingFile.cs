namespace Classwork
{
    using System.IO;
    using System;
    using System.Collections.Generic;
    public class StartupUsingFile
    {
        public static void Main()
        {
           File.Create("test.txt"); // създава файла директно в директорията (директен път)
            File.ReadAllText("test.txt"); // Или даваме пълния път до файла (директен път)

            //Релативен път: ../  означава - качи се една
            //директория нагоре и там ми създай файла

            //../../тест.тхт - върни се две директории нагоре и там създай файла

            var numbers = File.ReadAllText("numbers.txt.txt");
           Console.WriteLine(numbers);

            File.Copy("numbers.txt.txt", "../another.txt");

            Console.WriteLine(File.Exists("hshshsh.txt"));

            var newPath = "../another.txt";
            if (!File.Exists(newPath))
            {
               File.Copy("numbers.txt.txt", "../another.txt", true); //true - позволява презаписване на файла

            }

            File.Move("numbers.txt.txt", "abv.txt");
           File.Delete("abv.txt");

            var newtext = File.ReadAllLines("numbers.txt.txt");
            foreach (var line in newtext)
            {
                Console.WriteLine(line);
            }

           File.WriteAllText("novFile.txt", "Eto tozi text!!!");

           List<string>  listOfLines = new List<string>();
            listOfLines.Add("red");
            listOfLines.Add("red");
            listOfLines.Add("red");
            listOfLines.Add("red");
            listOfLines.Add("red");

            File.WriteAllLines("lines.txt", listOfLines);

            File.WriteAllLines("linesNext.txt", new string[]
            {
                "1 red",
                "2 red",
                "3 red",
                "4 red",
                "5 red",
                "6 red",
            });

            //добавяне на нов текс във вече съществуващ такъв:
            string text = File.ReadAllText("linesNext.txt");

            string newText = $"{text}7 red";
            File.WriteAllText("lines.txt", newText);
        }
    }
}
