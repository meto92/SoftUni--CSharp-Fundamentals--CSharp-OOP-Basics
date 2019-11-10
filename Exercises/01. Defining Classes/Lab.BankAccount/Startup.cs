using System;
using System.Collections.Generic;

public class Startup
{
    private static void Create(Dictionary<int, BankAccount> accounts, int id)
    {
        if (accounts.ContainsKey(id))
        {
            Console.WriteLine("Account already exists");
            return;
        }

        accounts[id] = new BankAccount(id);
    }

    private static void Deposit(Dictionary<int, BankAccount> accounts, int id, decimal amount)
    {
        if (!accounts.ContainsKey(id))
        {
            Console.WriteLine("Account does not exist");
            return;
        }

        accounts[id].Deposit(amount);
    }

    private static void Withdraw(Dictionary<int, BankAccount> accounts, int id, decimal amount)
    {
        if (!accounts.ContainsKey(id))
        {
            Console.WriteLine("Account does not exist");
            return;
        }

        accounts[id].Withdraw(amount);
    }

    private static void Print(Dictionary<int, BankAccount> accounts, int id)
    {
        if (!accounts.ContainsKey(id))
        {
            Console.WriteLine("Account does not exist");
            return;
        }

        Console.WriteLine(accounts[id]);
    }

    private static void TestClient()
    {
        Dictionary<int, BankAccount> accounts = new Dictionary<int, BankAccount>();

        string input;

        while ((input = Console.ReadLine()) != "End")
        {
            string[] items = input.Split(' ');

            string command = items[0];
            int id = 0;
            decimal amount = 0m;

            switch (command)
            {
                case "Create":
                    id = int.Parse(items[1]);

                    Create(accounts, id);
                    break;
                case "Deposit":
                    id = int.Parse(items[1]);
                    amount = decimal.Parse(items[2]);

                    Deposit(accounts, id, amount);
                    break;
                case "Withdraw":
                    id = int.Parse(items[1]);
                    amount = decimal.Parse(items[2]);

                    Withdraw(accounts, id, amount);
                    break;
                case "Print":
                    id = int.Parse(items[1]);

                    Print(accounts, id);
                    break;
                case "End":
                    return;
            }
        }
    }

    public static void Main()
    {
        BankAccount account = new BankAccount(1);

        account.Balance = 15;

        Console.WriteLine(account);
    }
}