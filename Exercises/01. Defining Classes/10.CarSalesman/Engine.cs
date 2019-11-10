using System;
using System.Text;

public class Engine
{
    private string model;
    private int power;
    private int? displacement;
    private string efficiency;

    public Engine(string model, int power, int? displacement, string efficiency)
    {
        this.Model = model;
        this.Power = power;
        this.Displacement = displacement;
        this.Efficiency = efficiency;
    }

    public string Model
    {
        get => model;
        set => model = value;
    }

    public int Power
    {
        get => power;
        set => power = value;
    }

    public int? Displacement
    {
        get => displacement;
        set => displacement = value;
    }

    public string Efficiency
    {
        get => efficiency ?? "n/a";
        set => efficiency = value;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        string displacement = string.IsNullOrEmpty(this.Displacement.ToString())
            ? "n/a"
            : this.Displacement.ToString();

        sb.Append($"  {this.Model}:{Environment.NewLine}");
        sb.Append($"    Power: {this.Power}{Environment.NewLine}");
        sb.Append($"    Displacement: {displacement}{Environment.NewLine}");
        sb.Append($"    Efficiency: {this.Efficiency}");

        return sb.ToString();
    }
}