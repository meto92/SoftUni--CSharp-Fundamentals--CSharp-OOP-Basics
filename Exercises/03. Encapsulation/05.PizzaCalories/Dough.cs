using System;

public class Dough
{
    public const int MinWeightInGrams = 1;
    public const int MaxWeightInGrams = 200;
    private const string InvalidTypeOfDoughExceptionMessage = "Invalid type of dough.";

    private enum FlourTypeMultiplier
    {
        white = 15, wholegrain = 10
    }

    private enum BakingTechniqueMultiplier
    {
        crispy = 9, chewy = 11, homemade = 10
    }

    private FlourTypeMultiplier flourTypeMultiplier;
    private BakingTechniqueMultiplier bakingTechniqueMultiplier;
    private int weightInGrams;

    public Dough(string flourType, string bakingTechnique, int weightInGrams)
    {
        this.FlourMultiplier = flourType.ToLower();
        this.BakingMultiplier = bakingTechnique.ToLower();
        this.WeightInGrams = weightInGrams;
    }    

    private string FlourMultiplier
    {
        set
        {
            if (!Enum.TryParse(value, out this.flourTypeMultiplier))
            {
                throw new ArgumentException(InvalidTypeOfDoughExceptionMessage);
            }
        }
    }

    private string BakingMultiplier
    {
        set
        {
            if (!Enum.TryParse(value, out this.bakingTechniqueMultiplier))
            {
                throw new ArgumentException(InvalidTypeOfDoughExceptionMessage);
            }
        }
    }

    public int WeightInGrams
    {
        get => this.weightInGrams;

        private set
        {
            if (value < MinWeightInGrams || value > MaxWeightInGrams)
            {
                throw new ArgumentException("Dough weight should be in the range [1..200].");
            }

            this.weightInGrams = value;
        }
    }

    public double CaloriesPerGram()
    {
        double flourTypeMultiplier = (double)this.flourTypeMultiplier / 10;
        double bakingTechniqueMultiplier = (double)this.bakingTechniqueMultiplier / 10;
        double caloriesPerGram = 2 * flourTypeMultiplier * bakingTechniqueMultiplier;

        return caloriesPerGram;
    }
}