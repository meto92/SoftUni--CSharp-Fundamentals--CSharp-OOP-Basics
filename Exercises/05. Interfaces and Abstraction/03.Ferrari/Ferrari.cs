public class Ferrari : ICar
{
    private string driver;

    public Ferrari(string driver)
    {
        this.Driver = driver;
    }

    public string Model => "488-Spider";

    public string Driver
    {
        get => this.driver;
        set => this.driver = value;
    }

    public string UseBreaks()
    {
        return "Brakes!";
    }

    public string PushTheGasPedal()
    {
        return "Zadu6avam sA!";
    }

    public override string ToString()
    {
        return $"{this.Model}/{this.UseBreaks()}/{this.PushTheGasPedal()}/{this.Driver}";
    }   
}