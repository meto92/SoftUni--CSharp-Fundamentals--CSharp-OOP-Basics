namespace MassEffect.Engine.Commands
{
    using System;
    using System.Text;
    using System.Linq;
    using System.Collections.Generic;

    using MassEffect.Interfaces;
    using MassEffect.GameObjects.Locations;

    public class SystemReportCommand : Command
    {
        public SystemReportCommand(IGameEngine gameEngine) 
            : base(gameEngine)
        { }

        private void AppendShips(StringBuilder result, string type, IEnumerable<IStarship> ships)
        {
            result.AppendLine($"{type} ships:");

            if (!ships.Any())
            {
                result.AppendLine("N/A");
            }
            else
            {
                foreach (IStarship ship in ships)
                {
                    result.AppendLine(ship.ToString());
                }
            }
        }

        public override void Execute(string[] commandArgs)
        {
            string starSystemName = commandArgs[1];

            StarSystem starSystem = base.GameEngine
                .Galaxy
                .GetStarSystemByName(starSystemName);

            IEnumerable<IStarship> intactShips = starSystem
                .Starships
                .Where(ship => ship.Health > 0)
                .OrderByDescending(ship => ship.Health)
                .ThenByDescending(ship => ship.Shields);
            IEnumerable<IStarship> destroyedShips = starSystem
                .Starships
                .Where(ship => ship.Health == 0)
                .OrderBy(ship => ship.Name);

            StringBuilder result = new StringBuilder();

            AppendShips(result, "Intact", intactShips);
            AppendShips(result, "Destroyed", destroyedShips);

            Console.WriteLine(result.ToString().TrimEnd());
        }
    }
}