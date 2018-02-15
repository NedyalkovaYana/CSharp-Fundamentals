using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Runtime.InteropServices;


    public class Startup
    {
        public static void Main()
        {
            var accounts = new Dictionary<int, BankAccount>();

            var input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                var inputLine = input.Split();
                var type = inputLine[0];

                switch (type)
                {
                    case "Create":
                        Create(inputLine, accounts);
                        break;
                    case "Deposit":
                        Deposit(inputLine, accounts);
                        break;
                    case "Withdraw":
                        Withdraw(inputLine, accounts);
                        break;
                    case "Print":
                        Print(inputLine, accounts);
                        break;
                }
            }

        }

        private static void Print(string[] inputLine, Dictionary<int, BankAccount> accounts)
        {
            var idForPrint = int.Parse(inputLine[1]);
            var findedId = false;
            foreach (var account in accounts)
            {
                if (account.Key == idForPrint)
                {
                    Console.WriteLine($"Account ID{account.Key}, balance {accounts[account.Key].Balance:f2}");
                    findedId = true;
                    return;
                }
            }
            if (findedId == false)
            {
                Console.WriteLine("Account does not exist");
            }
        }

        private static void Withdraw(string[] inputLine, Dictionary<int, BankAccount> accounts)
        {
            var id = int.Parse(inputLine[1]);
            var amount = decimal.Parse(inputLine[2]);

            if (!accounts.ContainsKey(id))
            {
                Console.WriteLine("Account does not exist");
                return;
            }
            if (accounts[id].Balance < amount)
            {
                Console.WriteLine("Insufficient balance");
                return;
            }
            accounts[id].Withdraw(amount);
        }

        private static void Deposit(string[] inputLine, Dictionary<int, BankAccount> accounts)
        {
            var id = int.Parse(inputLine[1]);
            var amount = decimal.Parse(inputLine[2]);
            if (!accounts.ContainsKey(id))
            {
                Console.WriteLine("Account does not exist");
            }
            else
            {
                accounts[id].Deposit(amount);
            }
        }


        private static void Create(string[] inputLine, Dictionary<int, BankAccount> accounts)
        {
            var id = int.Parse(inputLine[1]);
            if (accounts.ContainsKey(id))
            {
                Console.WriteLine("Account already exists");
            }
            else
            {
                var acc = new BankAccount();
                acc.Id = id;
                accounts.Add(id, acc);

            }
        }
    }


