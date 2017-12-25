using System.Linq;

namespace _05.HotPotato
{
    using System;
    using System.Collections.Generic;
    class HotPotato
    {
        static void Main()
        {
           var players =  new Queue<string>();

            Console.ReadLine().Split().ToList().ForEach(name => players.Enqueue(name));

            var indexOfDeletion = int.Parse(Console.ReadLine());

            Console.WriteLine($"Last is {GetLastPlayer(indexOfDeletion, players)}");
        }

        static string GetLastPlayer(int indexOfDeletion, Queue<string> players)
        {
            if (players.Count < 1 || players == null)
            {
                return string.Empty;
            }

            //Substract 1 from the index to match the Zero based indexation because of the remainder usage
            indexOfDeletion--;

            while (players.Count > 1)
            {
                var currentDeletionIndex = indexOfDeletion % players.Count;

                for (int i = 0; i < players.Count; i++)
                {
                    if (i == currentDeletionIndex)
                    {
                        Console.WriteLine($"Removed {players.Dequeue()}");
                        break;
                    }

                    var temp = players.Dequeue();
                    players.Enqueue(temp);
                }
            }
            return players.Dequeue();
        }
    }
}
