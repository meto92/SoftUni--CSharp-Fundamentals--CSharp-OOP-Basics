using System.Linq;
using System.Text;
using System.Collections.Generic;

public class Commando : SpecializedSoldier, ICommando
{
    private Dictionary<string, Mission> missions;

    public Commando(SpecializedSoldier specSoldier, IEnumerable<Mission> missions)
        : this(specSoldier.Id, specSoldier.FirstName, specSoldier.LastName, specSoldier.Salary, specSoldier.Corps, missions)
    { }

    public Commando(string id, string firstName, string lastName, decimal salary, Enums.Corps corps, IEnumerable<Mission> missions) 
        : base(id, firstName, lastName, salary, corps)
    {
        this.missions = new Dictionary<string, Mission>();

        foreach (Mission mission in missions)
        {
            this.missions[mission.CodeName] = mission;
        }
    }

    public IDictionary<string, Mission> Missions => this.missions;

    public void CompleteMission(string codeName)
    {
        if (this.missions.TryGetValue(codeName, out Mission mission))
        {
            mission.MissionState = Enums.MissionState.Finished;
        }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine(base.ToString());
        sb.AppendLine("Missions:");

        this.missions.Values
            .ToList()
            .ForEach(mission => sb.AppendLine($"  {mission}"));

        return sb.ToString().TrimEnd();
    }
}