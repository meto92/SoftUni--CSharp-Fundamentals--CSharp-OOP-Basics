using System;

public class Startup
{
    public static void Main()
    {
        string[] inputFoods = Console.ReadLine().Split();

        int happinessPoints = 0;

        foreach (string foodStr in inputFoods)
        {
            Food.Foods food = Food.Foods.OtherFood;

            try
            {
                food = Enum.Parse<Food.Foods>(foodStr, true);
            }
            catch (ArgumentException)
            { }

            Food foodObj = FoodFactory.GetFood(food);

            happinessPoints += foodObj.HappinessPoints;
        }

        Mood mood = MoodFactory.GetMood(happinessPoints);

        Console.WriteLine(happinessPoints);
        Console.WriteLine(mood);
    }
}