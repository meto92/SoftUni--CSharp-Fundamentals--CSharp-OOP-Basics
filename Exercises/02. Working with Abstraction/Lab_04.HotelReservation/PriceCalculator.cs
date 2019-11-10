public class PriceCalculator
{
    public enum Discounts
    {
        None = 0,
        SecondVisit = 10,
        VIP = 20
    }

    public enum SeasonMultiplier
    {
        Spring = 2,
        Summer = 4,
        Autumn = 1,
        Winter = 3
    }

    private decimal pricePerDay;
    private int numberOfDays;
    private Discounts discount;
    private SeasonMultiplier season;

    public PriceCalculator(decimal pricePerDay, int numberOfDays, SeasonMultiplier season, Discounts discount)
    {
        this.PricePerDay = pricePerDay;
        this.NumberOfDays = numberOfDays;
        this.Season = season;
        this.Discount = discount;
    }

    public decimal PricePerDay
    {
        get => pricePerDay;
        set => pricePerDay = value;
    }

    public int NumberOfDays
    {
        get => numberOfDays;
        set => numberOfDays = value;
    }

    public Discounts Discount
    {
        get => discount;
        set => discount = value;
    }

    public SeasonMultiplier Season
    {
        get => season;
        set => season = value;
    }

    public decimal CalculateHolidayPrice()
    {
        decimal percentageDiscount = (decimal)this.Discount / 100;
        decimal multiplier = (int)this.Season;
        decimal holidayPrice = this.PricePerDay * this.NumberOfDays * multiplier;
        holidayPrice -= holidayPrice * percentageDiscount;

        return holidayPrice;
    }
}