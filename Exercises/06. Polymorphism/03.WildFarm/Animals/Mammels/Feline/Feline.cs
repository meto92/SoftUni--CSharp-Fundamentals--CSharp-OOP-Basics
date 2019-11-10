public abstract class Feline : Mammal
{
    private string breed;
    
    public Feline(string name, double weight, string livingRegion, string breed) 
        : base(name, weight, livingRegion)
    {
        this.Breed = breed;
    }

    public string Breed
    {
        get => this.breed;

        set
        {
            Utility.ValidateNullOrEmptyString(value, nameof(this.Breed));

            this.breed = value;
        }
    }

    public override string ToString()
    {
        string result = $"{this.GetType().Name} [{base.Name}, {this.Breed}, {base.Weight}, {base.LivingRegion}, {base.FoodEaten}]";

        return result;
    }
}