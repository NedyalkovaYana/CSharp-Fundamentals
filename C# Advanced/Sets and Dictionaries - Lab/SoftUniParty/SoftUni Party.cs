using System.Text.RegularExpressions;

namespace SoftUniParty
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var vipGuests = new SortedSet<string>();
            var regularGuests = new SortedSet<string>();

            var guests = string.Empty;
            while ((guests = Console.ReadLine()) != "PARTY")
            {
               InputGuests(vipGuests, regularGuests, guests);                
            }

            while ((guests = Console.ReadLine()) != "END")
            {
                CheckMissingGuests(vipGuests, regularGuests, guests);
            }

            PrintMissingGuestLIst(vipGuests, regularGuests);
        }

        static void PrintMissingGuestLIst(SortedSet<string> vipGuests, SortedSet<string> regularGuests)
        {
            var totalMissingGuestCount = vipGuests.Count + regularGuests.Count;
            Console.WriteLine(totalMissingGuestCount);

            foreach (var vip in vipGuests)
            {
                Console.WriteLine($"{vip}");
            }
            foreach (var regular in regularGuests)
            {
                Console.WriteLine($"{regular}");
            }
        }

        static void CheckMissingGuests(SortedSet<string> vipGuests, SortedSet<string> regularGuests, string guests)
        {
            if (Regex.IsMatch(guests, @"^\d"))
            {
                if (vipGuests.Contains(guests))
                {
                    vipGuests.Remove(guests);
                }
            }
            else if (regularGuests.Contains(guests))
            { 
               regularGuests.Remove(guests);
            }
            else
            {
                return;
            }

        }


        static void InputGuests(SortedSet<string> vipGuests, SortedSet<string> regularGuests, string guests)
        {
            if (Regex.IsMatch(guests, @"^\d"))
            {
                vipGuests.Add(guests);
            }
            else
            {
                regularGuests.Add(guests);
            }
        }
    }
}
