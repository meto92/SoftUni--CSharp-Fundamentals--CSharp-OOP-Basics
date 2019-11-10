public class Mission : IMission
{
    private string codeName;
    private Enums.MissionState missionState;

    public Mission(string codeName, Enums.MissionState missionState)
    {
        this.CodeName = codeName;
        this.MissionState = missionState;
    }

    public Enums.MissionState MissionState
    {
        get => this.missionState;
        set => this.missionState = value;
    }

    public string CodeName
    {
        get => this.codeName;
        set => this.codeName = value;
    }

    public override string ToString()
    {
        return $"Code Name: {this.CodeName} State: {this.MissionState}";
    }
}