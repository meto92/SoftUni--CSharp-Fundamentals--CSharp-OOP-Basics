using System;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Collections.Generic;

public class NationsBuilder
{
    private BenderFactory benderFactory;
    private MonumentFactory monumentFactory;
    IList<string> nationsIssuedWars;
    private string[] nations;
    private IDictionary<string, List<IBender>> bendersByNation;
    private IDictionary<string, List<IMonument>> monumentsByNation;

    public NationsBuilder()
    {
        this.benderFactory = new BenderFactory();
        this.monumentFactory = new MonumentFactory();
        this.nationsIssuedWars = new List<string>();

        nations = Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(t => t.IsClass && t.Name.EndsWith(nameof(Bender)))
            .Select(t => t.Name.Substring(0, t.Name.Length - nameof(Bender).Length))
            .ToArray();

        this.bendersByNation = nations.ToDictionary(nation => nation, value => new List<IBender>());
        this.monumentsByNation = nations.ToDictionary(nation => nation, value => new List<IMonument>());
    }

    public void AssignBender(List<string> benderArgs)
    {
        string type = benderArgs[0];
        string name = benderArgs[1];
        int power = int.Parse(benderArgs[2]);
        double secondaryParameter = double.Parse(benderArgs[3]);

        IBender bender = benderFactory.CreateBender(type, name, power, secondaryParameter);
        
        this.bendersByNation[type].Add(bender);
    }

    public void AssignMonument(List<string> monumentArgs)
    {
        string type = monumentArgs[0];
        string name = monumentArgs[1];
        int affinity = int.Parse(monumentArgs[2]);

        IMonument monument = monumentFactory.CreateMonument(type, name, affinity);
        
        this.monumentsByNation[type].Add(monument);
    }

    private string JoinElements(string separator, IEnumerable<object> elements)
    {
        string result = string.Join(separator, 
            elements.Select(element => $"###{element}"));

        return result;
    }

    public string GetStatus(string nationsType)
    {
        StringBuilder result = new StringBuilder();

        result.AppendLine($"{nationsType} Nation");
        result.Append("Benders:");

        if (this.bendersByNation[nationsType].Count == 0)
        {
            result.AppendLine(" None");
        }
        else
        {
            result.AppendLine();
            result.Append(this.JoinElements(
                Environment.NewLine, 
                this.bendersByNation[nationsType]));
            result.AppendLine();
        }

        result.Append("Monuments:");

        if (this.monumentsByNation[nationsType].Count == 0)
        {
            result.Append(" None");
        }
        else
        {
            result.AppendLine();
            result.Append(this.JoinElements(
                Environment.NewLine,
                this.monumentsByNation[nationsType]));
        }

        return result.ToString();
    }

    public void IssueWar(string nationsType)
    {
        Dictionary<string, double> powerByNation = new Dictionary<string, double>();

        foreach (string nation in this.nations)
        {
            double totalPower = this.bendersByNation[nation].Sum(bender => bender.Power * bender.SecondaryParameter);

            totalPower += this.monumentsByNation[nation].Sum(monument => monument.Affinity) * totalPower / 100;

            powerByNation[nation] = totalPower;
        }

        foreach (KeyValuePair<string, double> pair 
            in powerByNation
                .OrderBy(p => p.Value)
                .Take(powerByNation.Count - 1))
        {
            string nation = pair.Key;

            this.bendersByNation[nation].Clear();
            this.monumentsByNation[nation].Clear();
        }

        this.nationsIssuedWars.Add(nationsType);
    }

    public string GetWarsRecord()
    {
        StringBuilder result = new StringBuilder();

        for (int i = 0; i < this.nationsIssuedWars.Count; i++)
        {
            result.AppendLine($"War {i + 1} issued by {this.nationsIssuedWars[i]}");
        }

        return result.ToString().TrimEnd();
    }
}