public abstract class Food
{
    public enum Foods
    {
        Cram,
        Lembas,
        Apple,
        Melon,
        HoneyCake,
        Mushrooms,
        OtherFood
    }

    public abstract int HappinessPoints
    {
        get;
    }
}