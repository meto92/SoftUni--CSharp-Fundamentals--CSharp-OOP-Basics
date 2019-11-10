public interface ICar
{
    string Brand
    {
        get;
    }

    string Model
    {
        get;
    }

    int YearOfProduction
    {
        get;
    }

    int Horsepower
    {
        get;
    }

    int Acceleration
    {
        get;
    }

    int Suspension
    {
        get;
    }

    int Durability
    {
        get;
    }

    void Tune(int tuneIndex, string tuneAddon);
}