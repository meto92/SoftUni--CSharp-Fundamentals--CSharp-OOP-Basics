﻿public class Pokemon
{
    private string name;
    private string element;
    private int health;

    public Pokemon(string name, string element, int health)
    {
        this.Name = name;
        this.Element = element;
        this.Health = health;
    }

    public string Name
    {
        get => name;
        set => name = value;
    }

    public string Element
    {
        get => element;
        set => element = value;
    }

    public int Health
    {
        get => health;
        set => health = value;
    }

}