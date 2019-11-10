using System;

public class Startup
{
    public static void Main()
    {
        string[] holidayParams = Console.ReadLine().Split();

        decimal pricePerDay = decimal.Parse(holidayParams[0]);
        int numberOfDays = int.Parse(holidayParams[1]);
        PriceCalculator.SeasonMultiplier seasonMultiplier = Enum.Parse<PriceCalculator.SeasonMultiplier>(holidayParams[2]);
        PriceCalculator.Discounts discount = PriceCalculator.Discounts.None;
        
        if (holidayParams.Length == 4)
        {
            discount = Enum.Parse<PriceCalculator.Discounts>(holidayParams[3]);
        }

        PriceCalculator priceCalculator = new PriceCalculator(pricePerDay, numberOfDays, seasonMultiplier, discount);

        decimal holidayPrice = priceCalculator.CalculateHolidayPrice();

        Console.WriteLine(holidayPrice.ToString("f2"));
    }
}