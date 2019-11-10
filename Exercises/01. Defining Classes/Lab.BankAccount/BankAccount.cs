using System;

public class BankAccount
{
    private int id;
    private decimal balance;

    public BankAccount()
        : this(0)
    { }

    public BankAccount(int id)
    {
        this.Id = id;
        this.Balance = 0m;
    }

    public int Id
    {
        get => id;
        set => id = value;
    }

    public decimal Balance
    {
        get => balance;
        set => balance = value;
    }

    public void Deposit(decimal amount)
    {
        this.Balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        if (this.Balance < amount)
        {
            Console.WriteLine("Insufficient balance");
            return;
        }
        
        this.Balance -= amount;
    }

    public override string ToString()
    {
        return $"Account {this.Id}, balance {this.Balance:f2}";
    }
}