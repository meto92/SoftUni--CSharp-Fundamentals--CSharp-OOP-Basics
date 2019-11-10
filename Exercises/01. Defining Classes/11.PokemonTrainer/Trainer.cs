using System.Collections.Generic;

public class Trainer
{
    private string name;
    private int badgesCount;
    private List<Pokemon> pokeons;

    public Trainer(string name)
    {
        this.Name = name;
        this.BadgesCount = 0;
        this.Pokemons = new List<Pokemon>();
    }

    public string Name
    {
        get => name;
        set => name = value;
    }

    public int BadgesCount
    {
        get => badgesCount;
        set => badgesCount = value;
    }

    public List<Pokemon> Pokemons
    {
        get => pokeons;
        set => pokeons = value;
    }

    public override string ToString()
    {
        return $"{this.Name} {this.BadgesCount} {this.Pokemons.Count}";
    }
}