using System;
using System.Linq;
using System.Reflection;

public class BenderFactory
{
    private const string BenderSuffix = nameof(Bender);

    public IBender CreateBender(string type, string name, int power, double secondaryParameter)
    {
        Type benderType = Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(t => t.IsClass)
            .FirstOrDefault(t => t.Name == type + BenderSuffix);

        if (benderType == null)
        {
            throw new ArgumentNullException(nameof(benderType), "Unknown bender");
        }

        IBender bender = (IBender) Activator.CreateInstance(benderType, name, power, secondaryParameter);

        return bender;
    }
}