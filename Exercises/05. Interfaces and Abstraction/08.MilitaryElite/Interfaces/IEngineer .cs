using System.Collections.Generic;

public interface IEngineer
{
    IList<Repair> Repairs
    {
        get;
    }
}