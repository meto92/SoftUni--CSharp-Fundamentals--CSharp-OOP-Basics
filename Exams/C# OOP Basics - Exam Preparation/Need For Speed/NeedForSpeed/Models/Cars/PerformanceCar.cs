using System.Linq;
using System.Text;
using System.Collections.Generic;

public class PerformanceCar : Car, IPerformanceCar
{
    private List<string> addOns;

    public PerformanceCar(
        string brand,
        string model,
        int yearOfProduction,
        int horsepower,
        int acceleration,
        int suspension,
        int durability)
        : base(
            brand,
            model,
            yearOfProduction,
            horsepower + (horsepower * 50) / 100,
            acceleration,
            suspension - (suspension * 25) / 100,
            durability)
    {
        this.addOns = new List<string>();
    }

    public ICollection<string> AddOns => this.addOns;

    public override void Tune(int tuneIndex, string tuneAddon)
    {
        base.Tune(tuneIndex, tuneAddon);
        this.AddOns.Add(tuneAddon);
    }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder();

        result.AppendLine(base.ToString());
        result.AppendFormat("Add-ons: {0}",
            this.AddOns.Any()
                ? string.Join(", ", this.AddOns)
                : "None");

        return result.ToString();
    }
}