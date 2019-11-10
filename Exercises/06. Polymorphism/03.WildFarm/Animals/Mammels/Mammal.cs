public abstract class Mammal : Animal
{
    private string livingRegion;    

    public Mammal(string name, double weight, string livingRegion) 
        : base(name, weight)
    {
        this.LivingRegion = livingRegion;
    }

    public string LivingRegion
    {
        get => this.livingRegion;
        set => this.livingRegion = Utility.ValidateNullOrEmptyString(value, nameof(this.LivingRegion));
    }

    public override string ToString()
    {
        string result = $"{base.ToString()}, {base.Weight}, {this.LivingRegion}, {base.FoodEaten}]";

        return result;
    }
}