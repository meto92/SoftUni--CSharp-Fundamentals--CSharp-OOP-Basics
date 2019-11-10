using System;
using System.Linq;
using System.Reflection;

public class MonumentFactory
{
    private const string MonumentSuffix = nameof(Monument);

    public IMonument CreateMonument(string type, string name, int affinity)
    {
        Type monumentType = Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(t => t.IsClass)
            .FirstOrDefault(t => t.Name == type + MonumentSuffix);

        if (monumentType == null)
        {
            throw new ArgumentNullException(nameof(monumentType), "Unknown monument");
        }

        IMonument monument = (IMonument) Activator.CreateInstance(monumentType, name, affinity);

        return monument;
    }
}