using System.Text;
using System.Collections.Generic;

public class LeutenantGeneral : Private, ILeutenantGeneral
{
    private List<Private> privatesUnderCommand;

    public LeutenantGeneral(Private privateObj, IEnumerable<Private> privates)
        : this(privateObj.Id, privateObj.FirstName, privateObj.LastName, privateObj.Salary, privates)
    { }

    public LeutenantGeneral(string id, string firstName, string lastName, decimal salary, IEnumerable<Private> privates)
        : base(id, firstName, lastName, salary)
    {
        this.privatesUnderCommand = new List<Private>();

        this.privatesUnderCommand.AddRange(privates);
    }

    public IList<Private> PrivatesUnderCommand
    {
        get => this.privatesUnderCommand;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine(base.ToString());
        sb.AppendLine("Privates:");

        this.privatesUnderCommand.ForEach(priv => sb.AppendLine($"  {priv}"));

        return sb.ToString().TrimEnd();
    }
}