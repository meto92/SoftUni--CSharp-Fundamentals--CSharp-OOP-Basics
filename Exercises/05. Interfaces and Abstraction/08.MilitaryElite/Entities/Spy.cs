﻿using System.Text;

public class Spy : Soldier, ISpy
{
    private int codeNumber;

    public Spy(Soldier soldier, int codeNumber)
        : this(soldier.Id, soldier.FirstName, soldier.LastName, codeNumber)
    { }

    public Spy(string id, string firstName, string lastName, int codeNumber) 
        : base(id, firstName, lastName)
    {
        this.CodeNumber = codeNumber;
    }

    public int CodeNumber
    {
        get => this.codeNumber;
        set => this.codeNumber = value;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine(base.ToString());
        sb.Append($"Code Number: {this.CodeNumber}");

        return sb.ToString();
    }
}