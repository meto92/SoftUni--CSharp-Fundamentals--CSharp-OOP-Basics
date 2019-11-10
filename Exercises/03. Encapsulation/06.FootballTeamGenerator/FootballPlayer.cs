public class FootballPlayer
{
    private string name;
    private int endurance;
    private int sprint;
    private int drible;
    private int passing;
    private int shooting;

    public FootballPlayer(string name, int endurance, int sprint, int drible, int passing, int shooting)
    {
        this.Name = name;
        this.Endurance = endurance;
        this.Sprint = sprint;
        this.Drible = drible;
        this.Passing = passing;
        this.Shooting = shooting;
    }

    public string Name
    {
        get => this.name;
        private set => this.name = Utility.ValidateName(value);
    }

    public int Endurance
    {
        get => this.endurance;
        private set => this.endurance = Utility.ValidateFootballPlayerStat(value, "Endurance");
    }

    public int Sprint
    {
        get => this.sprint;
        private set => this.sprint = Utility.ValidateFootballPlayerStat(value, "Sprint");
    }

    public int Drible
    {
        get => this.drible;
        private set => this.drible = Utility.ValidateFootballPlayerStat(value, "Drible");
    }

    public int Passing
    {
        get => this.passing;
        private set => this.passing = Utility.ValidateFootballPlayerStat(value, "Passing");
    }

    public int Shooting
    {
        get => this.shooting;
        private set => this.shooting = Utility.ValidateFootballPlayerStat(value, "Shooting");
    }

    public double AverageSkillLevel => CalcAverageSkillLevel();

    private double CalcAverageSkillLevel()
    {
        double skillLevelsSum = this.Endurance + this.Sprint + this.Drible + this.Passing + this.Shooting;

        return skillLevelsSum / 5;
    }
}