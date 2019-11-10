using System;
using System.Text;

public class Car
{
    private string model;
    private Engine engine;
    private int? weight;
    private string color;

    public Car(string model, Engine engine, int? weight, string color)
    {
        this.Model = model;
        this.Engine = engine;
        this.Weight = weight;
        this.Color = color;
    }

    public string Model
    {
        get => model;
        set => model = value;
    }

    public Engine Engine
    {
        get => engine;
        set => engine = value;
    }

    public int? Weight
    {
        get => weight;
        set => weight = value;
    }

    public string Color
    {
        get => color ?? "n/a";
        set => color = value;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        string weight = string.IsNullOrEmpty(this.Weight.ToString())
            ? "n/a" 
            : this.Weight.ToString();
        
        sb.Append($"{this.Model}:{Environment.NewLine}");
        sb.Append($"{this.Engine}{Environment.NewLine}");
        sb.Append($"  Weight: {weight}{Environment.NewLine}");
        sb.Append($"  Color: {this.Color}");

        return sb.ToString();
    }
}