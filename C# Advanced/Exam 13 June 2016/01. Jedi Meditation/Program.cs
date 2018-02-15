using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Jedi_Meditation
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var master = new List<string>();
            var knight = new List<string>();
            var padawan = new List<string>();
            var toshkoSlav = new List<string>();
            var masterYoda = new List<string>();


            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < tokens.Length; j++)
                {
                    var currentJedi = tokens[j].ToLower();

                    if (currentJedi.StartsWith("m"))
                    {
                        master.Add(currentJedi);
                    }
                    else if (currentJedi.StartsWith("k"))
                    {
                        knight.Add(currentJedi);
                    }
                    else if (currentJedi.StartsWith("p"))
                    {
                        padawan.Add(currentJedi);
                    }
                    else if (currentJedi.StartsWith("t"))
                    {
                        toshkoSlav.Add(currentJedi);
                    }
                    else if (currentJedi.StartsWith("s"))
                    {
                        toshkoSlav.Add(currentJedi);
                    }
                    else if (currentJedi.StartsWith("y"))
                    {
                        masterYoda.Add(currentJedi);
                    }
                }
            }
            if (masterYoda.Any())
            {
                Console.WriteLine(string.Join(" ", master) + " " + string.Join(" ", knight) + " "
                    + string.Join(" ", toshkoSlav) + " " + string.Join(" ", padawan));
            }
            else
            {
                Console.WriteLine(string.Join(" ", toshkoSlav) + " " + string.Join(" ", master) + " " +
                    string.Join(" ", knight) + " " + string.Join(" ", padawan));
            }
           
        }
    }
}
