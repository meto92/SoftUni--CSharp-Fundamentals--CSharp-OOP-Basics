using System;
using System.Collections.Generic;

public class Person
{
    private string name;
    private decimal money;
    private List<Product> bag;

    public Person(string name, decimal money)
    {
        this.Name = name;
        this.Money = money;
        this.Bag = new List<Product>();
    }

    public string Name
    {
        get => this.name;

        set
        {
            if (string.IsNullOrEmpty(value) || value.Trim() == string.Empty)
            {
                throw new ArgumentException("Name cannot be empty");
            }

            this.name = value;
        }
    }

    public decimal Money
    {        
        get => this.money;

        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }

            this.money = value;
        }
    }

    public List<Product> Bag
    {
        get => this.bag;
        set => this.bag = value;
    }

    public override string ToString()
    {
        return string.Format("{0} - {1}",
            this.Name,
            this.Bag.Count == 0 
                ? "Nothing bought"
                : string.Join(", ", bag));
    }
}