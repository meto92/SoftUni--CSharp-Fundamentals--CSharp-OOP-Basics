using System.Text;
using System.Collections.Generic;

public class Engineer : SpecializedSoldier, IEngineer
{
    private List<Repair> repairs;

    public Engineer(SpecializedSoldier specSoldier, IEnumerable<Repair> repairs)
        : this(specSoldier.Id, specSoldier.FirstName, specSoldier.LastName, specSoldier.Salary, specSoldier.Corps, repairs)
    { }

    public Engineer(string id, string firstName, string lastName, decimal salary, Enums.Corps corps, IEnumerable<Repair> repairs) 
        : base(id, firstName, lastName, salary, corps)
    {
        this.repairs = new List<Repair>();

        this.repairs.AddRange(repairs);
    }

    public IList<Repair> Repairs => this.repairs;

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine(base.ToString());
        sb.AppendLine("Repairs:");

        this.repairs.ForEach(repair => sb.AppendLine($"  {repair}"));

        return sb.ToString().TrimEnd();
    }
}