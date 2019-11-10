using System.Collections.Generic;

public interface IGarage
{
    ICollection<ICar> ParkedCars
    {
        get;
    }

    void TuneParkedCars(int tuneIndex, string tuneAddon);
}