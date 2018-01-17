namespace _13.TriFunction
{
    using System;
    using System.Linq;
    class ТriFunction
    {
        static void Main()
        {
            var num = int.Parse(Console.ReadLine());

            var names = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

            //sort name by length (this is only my test)

            //names = names.OrderBy(a => a.Length).ToArray();
            //Console.WriteLine(string.Join(Environment.NewLine, names));

            GetSumOfCharactersByName(names, num);
        }

        static void GetSumOfCharactersByName(string[] names, int num)
        {
            var sumOfChars = 0;
            foreach (var name in names)
            {
                var currentName = name;
                sumOfChars = currentName.Sum(b => b);

                if (sumOfChars >= num)
                {
                    Console.WriteLine($"{name}");
                    return;
                }
            }
        }
    }
}
