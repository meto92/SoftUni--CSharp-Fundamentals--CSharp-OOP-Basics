namespace MassEffect.Engine.Commands
{
    using System;
    using System.Linq;

    using MassEffect.Exceptions;
    using MassEffect.GameObjects.Enhancements;
    using MassEffect.GameObjects.Locations;
    using MassEffect.GameObjects.Ships;
    using MassEffect.Interfaces;

    public class CreateCommand : Command
    {
        public CreateCommand(IGameEngine gameEngine) 
            : base(gameEngine)
        { }

        public override void Execute(string[] commandArgs)
        {
            string shipType = commandArgs[1];
            string shipName = commandArgs[2];
            string starSystemName = commandArgs[3];

            if (base.GameEngine.Starships.Any(ship => ship.Name == shipName))
            {
                throw new ShipException(Messages.DuplicateShipName);
            }

            StarshipType starshipType = (StarshipType) Enum.Parse(typeof(StarshipType), shipType);

            StarSystem starSystem = base.GameEngine.Galaxy.GetStarSystemByName(starSystemName);

            IStarship starship =  base.GameEngine.ShipFactory.CreateShip(starshipType, shipName, starSystem);

            if (commandArgs.Length > 4)
            {
                string[] enhancements = commandArgs.Skip(4).ToArray();

                foreach (string enhancementStr in enhancements)
                {
                    EnhancementType enhancementType = (EnhancementType)Enum.Parse(typeof(EnhancementType), enhancementStr);

                    Enhancement enhancement = base.GameEngine.EnhancementFactory.Create(enhancementType);

                    starship.AddEnhancement(enhancement);
                }
            }

            base.GameEngine.Starships.Add(starship);
            starSystem.Starships.Add(starship);

            Console.WriteLine(string.Format(Messages.CreatedShip, shipType, shipName));
        }
    }
}