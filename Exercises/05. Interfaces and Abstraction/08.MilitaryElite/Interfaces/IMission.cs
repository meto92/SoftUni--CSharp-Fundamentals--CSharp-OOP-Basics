public interface IMission
{
    string CodeName
    {
        get;
    }

    Enums.MissionState MissionState
    {
        get;
    }
}