using System.Text;

public class Tesla : Car, ICar, IElectricCar
{
    private int battery;

    public Tesla(string model, string color, int battery)
        : base(model, color)
    {
        this.Battery = battery;
    }

    public int Battery
    {
        get => this.battery;
        set => this.battery = value;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"{this.Color} {this.GetType().Name} {this.Model} with {this.Battery} Batteries");
        sb.AppendLine(base.Start());
        sb.Append(base.Stop());

        return sb.ToString();
    }
}