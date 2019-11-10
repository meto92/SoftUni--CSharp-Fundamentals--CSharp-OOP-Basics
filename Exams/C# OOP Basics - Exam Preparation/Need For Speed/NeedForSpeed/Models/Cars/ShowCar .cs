using System.Text;

public class ShowCar : Car, IShowCar
{
    private int stars;

    public ShowCar(
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
            horsepower, 
            acceleration, 
            suspension, 
            durability)
    {
        this.Stars = 0;
    }

    public int Stars
    {
        get => this.stars;
        set => this.stars = value;
    }

    public override void Tune(int tuneIndex, string tuneAddon)
    {
        base.Tune(tuneIndex, tuneAddon);
        this.Stars += tuneIndex;
    }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder();

        result.AppendLine(base.ToString());
        result.Append($"{this.Stars} *");

        return result.ToString();
    }
}