using System.Collections.Generic;

public interface ICommando
{
    IDictionary<string, Mission> Missions
    {
        get;
    }

    void CompleteMission(string codeName);
}