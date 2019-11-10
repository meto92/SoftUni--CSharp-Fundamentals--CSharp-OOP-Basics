public abstract class Bird : Animal
{
    private double wingSize;    

    public Bird(string name, double weight, double wingSize) 
        : base(name, weight)
    {
        this.WingSize = wingSize;
    }

    public double WingSize
    {
        get => this.wingSize;
        set => this.wingSize = Utility.ValidateNonZeroPositiveNumber(value, nameof(this.WingSize));
    }

    public override string ToString()
    {
        string result = $"{base.ToString()}, {this.wingSize}, {base.Weight}, {base.FoodEaten}]";

        return result;
    }
}