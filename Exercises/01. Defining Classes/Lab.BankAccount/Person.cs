using System.Linq;
using System.Collections.Generic;

public class Person
{
    private string name;
    private int age;
    private List<BankAccount> accounts;

    public Person(string name, int age)
        : this(name, age, new List<BankAccount>())
    { }

    public Person(string name, int age, List<BankAccount> accounts)
    {
        this.Name = name;
        this.Age = age;
        this.Accounts = accounts;
    }

    public string Name
    {
        get => name;
        set => name = value;
    }

    public int Age
    {
        get => age;
        set => age = value;
    }

    public List<BankAccount> Accounts
    {
        get => accounts;
        set => accounts = value;
    }

    public decimal GetBalance()
    {
        return accounts.Sum(a => a.Balance);
    }
}