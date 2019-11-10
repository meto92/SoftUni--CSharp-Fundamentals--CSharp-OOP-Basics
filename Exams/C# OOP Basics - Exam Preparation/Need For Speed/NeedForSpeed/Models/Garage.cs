using System.Collections.Generic;

public class Garage : IGarage
{
    private HashSet<ICar> parkedCars;

    public Garage() => this.parkedCars = new HashSet<ICar>();

    public ICollection<ICar> ParkedCars => this.parkedCars;

    public void TuneParkedCars(int tuneIndex, string tuneAddOn)
    {
        foreach (ICar car in this.ParkedCars)
        {
            car.Tune(tuneIndex, tuneAddOn);
        }
    }
}