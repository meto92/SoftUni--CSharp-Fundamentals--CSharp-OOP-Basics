using System.Text;

public class Seat : Car, ICar
{
    public Seat(string model, string color)
        : base(model, color)
    { }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"{base.Color} {this.GetType().Name} {base.Model}");
        sb.AppendLine(base.Start());
        sb.Append(base.Stop());

        return sb.ToString();
    }
}