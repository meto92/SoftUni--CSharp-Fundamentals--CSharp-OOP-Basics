using System.Collections.Generic;

interface IPerformanceCar : ICar
{
    ICollection<string> AddOns
    {
        get;
    }
}