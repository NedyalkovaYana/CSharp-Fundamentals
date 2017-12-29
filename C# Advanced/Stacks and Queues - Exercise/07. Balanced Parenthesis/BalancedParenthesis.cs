namespace _07.Balanced_Parenthesis
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class BalancedParenthesis
    {
        static void Main()
        {
            var openParenthesis = new char[]
            {
                '[',
                '(',
                '{'
            };

            var closeParenthesis = new char[]
            {
                ']',
                ')',
                '}'
            };

            var input = Console.ReadLine().ToCharArray();
            var parenthesisHystory = new Stack<char>();
            var areBalanced = true;

            foreach (var symbol in input)
            {
                if (openParenthesis.Contains(symbol))
                {
                    parenthesisHystory.Push(symbol);
                    continue;
                }

                if (closeParenthesis.Contains(symbol))
                {
                    if (parenthesisHystory.Count == 0)
                    {
                        areBalanced = false;
                        break;
                    }

                    var openWith = parenthesisHystory.Pop();

                    if (!CheckBalance(openWith, symbol))
                    {
                        areBalanced = false;
                        break;
                    }
                }
            }

            Console.WriteLine(areBalanced ? "YES" : "NO");
        }

        static bool CheckBalance(char openWith, char closedWith)
        {
            switch (openWith)
            {
                case '(':
                    return (closedWith == ')') ? true : false;
                case '[':
                    return (closedWith == ']') ? true : false;
                case '{':
                    return (closedWith == '}') ? true : false;
                    default:
                        return false;
            }
        }
    }
}
