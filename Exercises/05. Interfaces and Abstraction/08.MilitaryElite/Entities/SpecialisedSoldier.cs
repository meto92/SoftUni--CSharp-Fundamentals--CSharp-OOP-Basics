using System.Text;

public class SpecializedSoldier : Private, ISpecializedSoldier
{
    private Enums.Corps corps;

    public SpecializedSoldier(Private privateObj, Enums.Corps corps)
        : this(privateObj.Id, privateObj.FirstName, privateObj.LastName, privateObj.Salary, corps)
    { }

    public SpecializedSoldier(string id, string firstName, string lastName, decimal salary, Enums.Corps corps)
       : base(id, firstName, lastName, salary)
    {
        this.Corps = corps;
    }

    public Enums.Corps Corps
    {
        get => this.corps;
        set => this.corps = value;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine(base.ToString());
        sb.Append($"Corps: {this.Corps}");

        return sb.ToString();
    }
}